using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace Base_Function.BASE_COMMON.Elements
{
    [Serializable]
    public abstract class PElement //: IAction
    {
        private int x;
        private int y;
        private int width;
        private int height;
        private Document document;
        private bool isSelected = false;
        private string name = string.Empty;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }        

        public bool IsSelected
        {
            get { return isSelected; }
            set { isSelected = value; }
        }

        public PElement()
        {
        }

        public PElement(int x, int y, int width, int height,string name,Document document)
        {
            this.document = document;
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
            this.name = name;
        }

        public int X
        {
            get
            {
                return x;
            }
            set
            {
                x = value;
            }
        }

        public int Y
        {
            get
            {
                return y;
            }
            set
            {
                y = value;
            }
        }

        public abstract bool Draw();

        public virtual bool MouseMove(int x, int y, MouseButtons button)
        {
            return true;
        }

        public virtual bool MouseDown(int x, int y, MouseButtons button)
        {
            return true;
        }

        public virtual bool MouseClick(int x, int y, MouseButtons button)
        {
            return false;
        }

        public virtual bool Contains(int x,int y)
        {
            return Bounds.Contains(x, y);
        }

        public int Width
        {
            get
            {
                return width;
            }
            set
            {
                width = value;
            }
        }

        public int Height
        {
            get
            {
                return height;
            }
            set
            {
                height = value;
            }
        }

        public virtual System.Drawing.Rectangle Bounds
        {
            get
            {
                return new Rectangle(x, y, width, height);
            }
        }


        public Document Document
        {
            get
            {
                return document;
            }
            set
            {
                document = value;
            }
        }

        public int RealBottom
        {
            get
            {
                return this.y + this.height;
            }
        }

        public int RealRight
        {
            get
            {
                return this.x + this.width;
            }
        }
    }
}
