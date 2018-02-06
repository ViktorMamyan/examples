using System;

namespace SampleData
{
    public class Subject
    {
        public String Description { get; set; }
        public String Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}