using System;
using System.Collections.Generic;
using System.Text;

namespace Base_Function.BASE_COMMON.Elements
{
    public class PCollectionAttributes : List<PAttribute>
    {
        public void SetValue(string name, object value)
        {
            PAttribute pattribute = this[name];
            if (pattribute != null)
            {
                pattribute.Value = value;
                return;
            }
            this.Add(new PAttribute(name, value));
        }

        public PAttribute this[string name]
        {
            get
            {
                foreach (PAttribute item in this)
                {
                    if (item.Name == name)
                        return item;
                }
                return null;
            }
        }
    }
}
