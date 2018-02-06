using System;
using System.Drawing;

namespace SampleData
{
    public class Publisher
    {
        public String Name { get; set; }
        public Bitmap Logo { get; set; }
        public String WebSite { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
