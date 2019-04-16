using System;
using System.Collections.Generic;
using System.Text;

namespace Base_Function.BASE_COMMON.Elements
{
    public class PAttribute
    {
        private string name = string.Empty;
        private object value = null;

        public PAttribute()
        {
 
        }

        public PAttribute(string name, object value)
        {
            this.Name = name;
            this.Value = value;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public object Value
        {
            get { return this.value; }
            set { this.value = value; }
        }
    }
}
