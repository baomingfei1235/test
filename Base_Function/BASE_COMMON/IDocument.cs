using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using Base_Function.BLL_PARTOGRAM;
using Base_Function.MODEL;

namespace Base_Function.BASE_COMMON
{
    public interface IDocument
    {
        void ViewPaint(Graphics g);
        void HandleDoubleClick();
        bool HandleClick(int x, int y, MouseButtons button);
        bool HandleMouseMove(int x, int y, MouseButtons button);
        bool HandleMouseDown(int x, int y, MouseButtons button);
        bool HandleMouseUp(int x, int y, MouseButtons button);
        bool PrintDocument();
        PUserInfo UserInfo
        {
            set;
            get;
        }
        ucPartogramDraw OwnerControl
        {
            get;
            set;
        }

        int Width
        {
            get;
        }

        int Height
        {
            get;
        }
    }
}
