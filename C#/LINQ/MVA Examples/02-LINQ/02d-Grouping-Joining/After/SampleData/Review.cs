using System;

namespace SampleData
{
    public class Review
    {
        public Book Book { get; set; }
        public User User { get; set; }
        public int Rating { get; set; }
        public String Comments { get; set; }
    }
}