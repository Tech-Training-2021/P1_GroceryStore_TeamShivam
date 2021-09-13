using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NatureFresh
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UsernameHolder"] != null)
            {
                RegisterBtn.Visible = false;
                NavbarUsernameLabel.Text = Session["UsernameHolder"].ToString();
            }
            else
            {
                LogOutBtn.Visible = false;
                RegisterBtn.Visible = true;
                NavbarUsernameLabel.Visible = false ;
            }
        }

        protected void RegisterBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }

            protected void LogOutBtn_Click(object sender, EventArgs e)
        {
            if (Session["UsernameHolder"] != null)
            {
                LogOutBtn.Visible = true;
                Session.Abandon();
                Response.Redirect("Default.aspx");
            }

        }

    }
}