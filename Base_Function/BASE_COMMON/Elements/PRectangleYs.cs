using System;
using System.Collections.Generic;
using System.Text;
using Base_Function.BLL_PARTOGRAM.InputControl;

namespace Base_Function.BASE_COMMON.Elements
{
    public class PRectangleYs : PRectangleTm
    {
        public PRectangleYs(int x, int y, int width, int height, string name, Document document)
            : base
                (x, y, width, height, name, document)
        {

        }

        public override bool MouseClick(int x, int y, System.Windows.Forms.MouseButtons button)
        {
            if (this.Contains(x, y))
            {
                using (frmYs ys = new frmYs(this.Content))
                {
                    if (ys.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        if (ys.GetStr == "无")
                        {
                            this.Content = "";
                        }
                        else
                        {
                            this.Content = ys.GetStr;
                        }
                    }
                }
                return true;
            }
            return false;
        }

        //public override bool Draw()
        //{
        //    return base.Draw();
        //}
    }
}
