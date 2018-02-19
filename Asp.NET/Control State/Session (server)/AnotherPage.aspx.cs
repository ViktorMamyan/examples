using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebSessions
{
    public partial class AnotherPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string text = Session["Key"] as string;
            if (text != null)
            {
                TextSession.Text = text;
            }
        }

        protected void DropSession_Click(object sender, EventArgs e)
        {
            //Delete all values from collection object
            //Session.Clear();

            //Delete collection object
            Session.Abandon();
            Response.Redirect(Request.Url.PathAndQuery);
        }
    }
}