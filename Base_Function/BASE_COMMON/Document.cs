using System;
using System.Collections.Generic;
using System.Text;
using Base_Function.BASE_COMMON.Elements;
using System.Drawing;
using System.Windows.Forms;
using Base_Function.MODEL;
using Base_Function.BLL_PARTOGRAM;

namespace Base_Function.BASE_COMMON
{
    public class Document : IDocument
    {
        private System.Drawing.Printing.PrintDocument docToPrint =
new System.Drawing.Printing.PrintDocument();//创建一个PrintDocument的实例
        private PContent content = new PContent();
        private DocumentView view = new DocumentView();
        private ucPartogramDraw ownerControl = null;
        private int wCount = 24;
        private PUserInfo userinfo = null;//
        private StringFormat format = new StringFormat();
        public int celWidht = 28;
        public int width = 827;
        public int height = 1169;

        public StringFormat Format
        {
            get { return format; }
            set { format = value; }
        }

        public PUserInfo Userinfo
        {
            get { return userinfo; }
            set { userinfo = value; }
        }

        public int Width
        {
            get
            {
                return this.width;
            }
        }

        public int Height
        {
            get
            {
                return this.height;
            }
        }

        public int WCount
        {
            get { return wCount; }
            set { wCount = value; }
        }

        public Document()
        {
            userinfo = new PUserInfo(this);
            format.LineAlignment = StringAlignment.Center;
            format.Alignment = StringAlignment.Center;
            format.FormatFlags = 0;// StringFormatFlags.DirectionRightToLeft;

            PPrintLog printLog = new PPrintLog(200, 98, Resource.logo.Width, Resource.logo.Height, "", this, (Image)Resource.logo);
            this.Elements.Add(printLog);
            PDrawTime p2 = new PDrawTime(89, 234, 0, 28, "时  间", this);
            this.Elements.Add(p2);
            //姓名
            PDrawHeader pxm = new PDrawHeader(p2.X, 180, 200, 20, "姓名：", this);
            this.Elements.Add(pxm);
            //年龄
            PDrawHeader pnl = new PDrawHeader(pxm.X + 130, pxm.Y, pxm.Width, pxm.Height, "年龄：", this);
            this.Elements.Add(pnl);
            //病室
            PDrawHeader pbs = new PDrawHeader(pnl.X + 130, pxm.Y, pxm.Width, pxm.Height, "病室：", this);
            this.Elements.Add(pbs);
            //床号
            PDrawHeader pch = new PDrawHeader(pbs.X + 130, pxm.Y, pxm.Width, pxm.Height, "床号：", this);
            this.Elements.Add(pch);
            //住院号
            PDrawHeader pzyh = new PDrawHeader(pch.X + 130, pxm.Y, pxm.Width, pxm.Height, "住院号：", this);
            this.Elements.Add(pzyh);

            //孕
            PDrawHeader py = new PDrawHeader(pxm.X, 210, 50, 20, "孕", this);
            this.Elements.Add(py);
            //产
            PDrawHeader pc = new PDrawHeader(pxm.X + 25, py.Y, 50, 20, "产", this);
            this.Elements.Add(pc);

            PDrawHeader pyz = new PDrawHeader(pnl.X, py.Y, pnl.Width, pnl.Height, "孕周：", this);
            this.Elements.Add(pyz);

            PDrawHeader psg = new PDrawHeader(pbs.X, py.Y, pbs.Width, pbs.Height, "身高：", this);
            this.Elements.Add(psg);

            PDrawHeader ptz = new PDrawHeader(pch.X, py.Y, pch.Width, pch.Height, "体重：", this);
            this.Elements.Add(ptz);


            PWgCurve pwg = new PWgCurve(p2.X, p2.RealBottom, this);
            userinfo.Pwg = pwg;
            p2.Width = pwg.Width;
            this.Elements.Add(pwg);
            PDrawTimeHours pth = new PDrawTimeHours(p2.X, pwg.RealBottom, p2.Width, 28, "", this);
            this.Elements.Add(pth);
            PTxy txy = new PTxy(p2.X, pth.RealBottom, p2.Width, 28, "胎心音", this);
            this.Elements.Add(txy);
            PTm tm = new PTm(p2.X, txy.RealBottom, p2.Width, 28, "胎  膜", this);
            this.Elements.Add(tm);
            PYs ys = new PYs(p2.X, tm.RealBottom, p2.Width, 28, "羊  水", this);
            this.Elements.Add(ys);
            PGs gs = new PGs(p2.X, ys.RealBottom, p2.Width, 28, "宫  缩", this);
            this.Elements.Add(gs);
            PXy xy = new PXy(p2.X, gs.RealBottom, p2.Width, 28, "血  压", this);
            this.Elements.Add(xy);
            POther other = new POther(p2.X, xy.RealBottom, p2.Width, 268, "治疗及其他", this);
            this.Elements.Add(other);
            PQm qm = new PQm(p2.X, other.RealBottom, p2.Width, 60, "签  名", this);
            this.Elements.Add(qm);

        }

        public DocumentView View
        {
            get { return view; }
            set { view = value; }
        }

        public ucPartogramDraw OwnerControl
        {
            get { return ownerControl; }
            set { ownerControl = value; }
        }

        /// <summary>
        /// 元素集合
        /// </summary>
        public List<PElement> Elements
        {
            get
            {
                return content.Element;
            }
        }

        public bool PrintDocument()
        {
            
            using (PrintDialog p = new PrintDialog())
            {
                //p.AllowCurrentPage = false;
                //p.AllowSelection = false;
                //p.AllowSomePages = false;
                //if (p.ShowDialog() == DialogResult.OK)
                p.AllowSomePages = true;
                p.ShowHelp = true;
                p.UseEXDialog = true;//不设置此属性,win7X64环境下ShowDialog()没反应;
                p.Document = docToPrint;//把PrintDialog的Document属性设为上面配置好的PrintDocument的实例
                DialogResult result = p.ShowDialog();//调用PrintDialog的ShowDialog函数显示打印对话框
                if (result == DialogResult.OK)
                {
                    PPrintDocument document = new PPrintDocument(this);
                    document.PrinterSettings = p.PrinterSettings;
                    //document.DefaultPageSettings = new System.Drawing.Printing.PageSettings(p.PrinterSettings);
                    document.Print();
                }
            }
            return false;
        }

        public void ViewPaint(Graphics g)
        {
            view.Graph = g;
            foreach (PElement ement in Elements)
            {
                ement.Draw();
            }
        }

        public void RefreshSize()
        {
            throw new NotImplementedException();
        }

        public void HandleDoubleClick()
        {
            throw new NotImplementedException();
        }

        public bool HandleClick(int x, int y, MouseButtons button)
        {
            foreach (PElement ement in Elements)
            {
                if (ement.MouseClick(x, y, button))
                     return true;
            }
            return false;
        }

        public bool HandleMouseMove(int x, int y, MouseButtons button)
        {
            foreach (PElement ement in Elements)
            {
                if (ement.MouseMove(x, y, button))
                    return true;
            }
            return false;
        }

        public bool HandleMouseDown(int x, int y, MouseButtons button)
        {
            foreach (PElement element in Elements)
            {
                if (element.MouseDown(x, y, button))
                    return true;
            }
            return false;
        }

        public bool HandleMouseUp(int x, int y, MouseButtons button)
        {
            throw new NotImplementedException();
        }

        public void RefreshView()
        {
            throw new NotImplementedException();
        }


        public PUserInfo UserInfo
        {
            get
            {
                return this.userinfo;
            }
            set
            {
                this.userinfo = value;
            }
        }

        public void SetElementValue(string name,string value)
        {
            foreach (PElement element in this.Elements)
            {
                if(element is PDrawHeader)
                {
                    PDrawHeader header = (PDrawHeader)element;
                    if (header.Name == name)
                    {
                        header.Content = value;
                        break;
                    }
                }
            }
        }

        #region 将数字时间转中文时间
        /// <summary>
        /// 将阿拉伯数字转换为中文简体
        /// </summary>
        /// <param name="time">HH:mm</param>
        /// <returns></returns>
        public static string ConvertText(string time)
        {
            string[] stringArr = time.Split(':');
            if (stringArr.Length > 1)
            {
                int temperHour = Convert.ToInt32(stringArr[0]);
                int temperMinute = Convert.ToInt32(stringArr[1]);

                return NumForChinese(temperHour, 0) + "时" + NumForChinese(temperMinute, 1) + "分";
            }
            return "";
        }

        public static string NumForChinese(int number, int type)
        {
            string returnTime = "";
            if (number < 10)
            {
                if (type == 1)
                {
                    returnTime = "零";
                }
                if (number == 0)
                {
                    returnTime = "零";
                }
                else
                {
                    switch (number)
                    {
                        case 1:
                            returnTime += "一";
                            break;
                        case 2:
                            returnTime += "二";
                            break;
                        case 3:
                            returnTime += "三";
                            break;
                        case 4:
                            returnTime += "四";
                            break;
                        case 5:
                            returnTime += "五";
                            break;
                        case 6:
                            returnTime += "六";
                            break;
                        case 7:
                            returnTime += "七";
                            break;
                        case 8:
                            returnTime += "八";
                            break;
                        case 9:
                            returnTime += "九";
                            break;
                    }
                }
            }
            else
            {
                switch (Convert.ToInt32(number.ToString().Substring(0, 1)))
                {
                    case 1:
                        returnTime = "十";
                        break;
                    case 2:
                        returnTime = "二十";
                        break;
                    case 3:
                        returnTime = "三十";
                        break;
                    case 4:
                        returnTime = "四十";
                        break;
                    case 5:
                        returnTime = "五十";
                        break;
                }
                switch (Convert.ToInt32(number.ToString().Substring(1, 1)))
                {
                    case 1:
                        returnTime += "一";
                        break;
                    case 2:
                        returnTime += "二";
                        break;
                    case 3:
                        returnTime += "三";
                        break;
                    case 4:
                        returnTime += "四";
                        break;
                    case 5:
                        returnTime += "五";
                        break;
                    case 6:
                        returnTime += "六";
                        break;
                    case 7:
                        returnTime += "七";
                        break;
                    case 8:
                        returnTime += "八";
                        break;
                    case 9:
                        returnTime += "九";
                        break;
                }
            }
            return returnTime;
        }
        #endregion
    }
}
