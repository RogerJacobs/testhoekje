using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Home : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["WorkFolder"] != null)
        {
            TextBox1.Text = Request.Cookies["WorkFolder"].Value;
            VSGIframe.Attributes.Add("href", TextBox1.Text + "/IAM.svg");
        }

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        HttpCookie cookie = new HttpCookie("WorkFolder");
        cookie.Value = TextBox1.Text;
        VSGIframe.Attributes.Add("href", TextBox1.Text + "/IAM.svg");
        Response.SetCookie(cookie);
    }
}