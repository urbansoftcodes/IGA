using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Runtime.InteropServices;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;
using ABLL;
using ADAL;
public partial class amain : System.Web.UI.MasterPage
{
    ADAL.ADAL cobj = new ADAL.ADAL();
    public static DataTable dtAdmin;
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Session["aid"]==null)
        {
            Response.Redirect("Default.aspx");
        }
        if (!IsPostBack)
        {
            Response.Cookies.Add(new HttpCookie("csrf", ""));
            if (Request.Cookies["csrf"] == null || Request.Cookies["csrf"].ToString().Trim() == "")
            {
                string csrftoken = cobj.RNGCharacterMask16();
            Response.Cookies.Add(new HttpCookie("csrf", csrftoken));
            lblhcsrf.Text = csrftoken;
            }

            if (Session["aid"] == null)
            {
                Response.Redirect("Default.aspx");
            }
            else
            {
                dtAdmin = (DataTable)Session["aid"];
                lblAdmin.Text = dtAdmin.Rows[0]["AdminName"].ToString().Trim();
            }

        }
    }

    protected void lbtnTypes_Click(object sender, EventArgs e)
    {
        Response.Redirect("ATypes.aspx");
    }

    protected void lbtnLogout_Click(object sender, EventArgs e)
    {
        Session.Clear();
        Session.RemoveAll();
        Session.Abandon();

        if (Request.Cookies["ASP.NET_SessionId"] != null)
        {
            Response.Cookies["ASP.NET_SessionId"].Value = string.Empty;
            Response.Cookies["ASP.NET_SessionId"].Expires = DateTime.Now.AddMonths(-20);
        }

        if (Request.Cookies["aid"] != null)
        {
            Response.Cookies["aid"].Value = string.Empty;
            Response.Cookies["aid"].Expires = DateTime.Now.AddMonths(-20);
        }

        Response.Redirect("Default.aspx");
    }

    protected void lbtnCategory_Click(object sender, EventArgs e)
    {
        Response.Redirect("ACategory.aspx");
    }
    protected void lbtnSubCategory_Click(object sender, EventArgs e)
    {
        Response.Redirect("ASubCategory.aspx");
    }
    protected void lbtnSCategorySub_Click(object sender, EventArgs e)
    {
        Response.Redirect("ASCategorySub.aspx");
    }
    protected void lbtnContents_Click(object sender, EventArgs e)
    {
        Response.Redirect("AContents.aspx");
    }
    protected void lbtnEnquiries_Click(object sender, EventArgs e)
    {
        Response.Redirect("AEnquiries.aspx");
    }
    protected void lbtnHomeBanner_Click(object sender, EventArgs e)
    {
        Response.Redirect("AHomeBanners.aspx");
    }
}
