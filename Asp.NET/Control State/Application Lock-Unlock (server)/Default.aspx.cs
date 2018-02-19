using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppLock
{
    public partial class Default : System.Web.UI.Page
    {
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Application.Lock();

            int counter = 0;

            if(Application["counter"] != null)
            {
                counter = (int)Application["counter"];
            }

            Application["counter"] = ++counter;
            Label1.Text = counter.ToString();

            Application.UnLock();
        }

    }
}