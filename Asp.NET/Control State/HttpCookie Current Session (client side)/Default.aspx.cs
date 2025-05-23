﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Http_Cookie
{
    public partial class Default : System.Web.UI.Page
    {
        protected void SaveCookie_Click(object sender, EventArgs e)
        {
            //create cookie for current session
            HttpCookie cookie = new HttpCookie("textCookie",Text1.Text);
            Response.Cookies.Add(cookie);

            Text1.Text = string.Empty;

            Response.Write("Cookie Saved");
        }

        protected void ReadCookie_Click(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["textCookie"];

            if (cookie != null)
            {
                Text1.Text = cookie.Value;
            }
            else
            {
                Text1.Text = "There is no coockie";
            }

        }

    }
}