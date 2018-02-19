using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebSessions
{
    public partial class Default : System.Web.UI.Page
    {

        protected void SaveSession_Click(object sender, EventArgs e)
        {
            Session["Key"] = Text1.Text;

            //Time out 1 min
            //Default 20 min
            Session.Timeout = 1;
        }

    }
}