using System;

namespace Application_State
{
    public partial class Default : System.Web.UI.Page
    {
        private static string key = "counter";

        public int Counter
        {
            get
            {
                object obj = Application[key];
                if (obj == null)
                {
                    Application[key] = 0;
                    return 0;
                }

                return (int)obj;
            }
            set
            {
                Application[key] = value;
            }
        }

        protected void AddOne_Click(object sender, EventArgs e)
        {
            Counter += 1;
            counter.Text = Counter.ToString();
        }

        protected void AddTwo_Click(object sender, EventArgs e)
        {
            Counter += 2;
            counter.Text = Counter.ToString();
        }
    }
}