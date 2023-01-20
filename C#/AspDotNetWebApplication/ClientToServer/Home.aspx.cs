using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClientToServer
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string namekey = Request.QueryString["name"];
            string idkey = Request.QueryString["userid"];
            string adultkey = Request.QueryString["adult"];
            Response.Write(namekey);
            Response.Write(idkey);
            Response.Write(adultkey);
            //string name = Request.Form["TextBox1"];

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("second.aspx?name=from-home-page");
        }
    }
}