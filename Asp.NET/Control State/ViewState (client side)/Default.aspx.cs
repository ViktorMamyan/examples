using System;

namespace State
{
    public partial class Default : System.Web.UI.Page
    {
        int counter = 0;

        protected void AddOne_Click(object sender, EventArgs e)
        {
            object obj = ViewState["counter"];
            if (obj != null)
            {
                counter = (int)obj;
            }
            counter += 1;
            ViewState["counter"] = counter;
        }

        protected void AddTwo_Click(object sender, EventArgs e)
        {
            object obj = ViewState["counter"];
            if (obj != null)
            {
                counter = (int)obj;
            }
            counter += 2;
            ViewState["counter"] = counter;
        }

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            Label1.Text = Convert.ToString(ViewState["counter"]);
        }

    }
}