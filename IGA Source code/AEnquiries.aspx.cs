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
public partial class AEnquiries : System.Web.UI.Page
{
    ADAL.ADAL cobj = new ADAL.ADAL();
    RDAL obj1 = new RDAL();
    HttpCookie cultureCookie;
    public static DataTable dtEnquiries;
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            LoadEnquiries();
        }
    }

  
    public void LoadEnquiries()
    {
        Regsc pobj = new Regsc();
        pobj.CType = "sall";
        dtEnquiries = obj1.GetRegsc(pobj);
        gv.DataSource = dtEnquiries;
        gv.DataBind();
    }

    protected void lbtnEdit_Click(object sender, EventArgs e)
    {
        using (GridViewRow row = (GridViewRow)((LinkButton)sender).Parent.Parent)
        {
            string sid = (row.FindControl("lblveid") as Label).Text.Trim();
            Response.Redirect("AEnquiry.aspx?c=" + cobj.Encrypt(sid));
        }
    }


    #region grid view 
    //grid view
    public override void VerifyRenderingInServerForm(Control control)
    {

    }
    protected void gv_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gv.PageIndex = e.NewPageIndex;
        LoadEnquiries(); //bindgridview will get the data source and bind it again
    }


    protected void gv_Sorting(object sender, GridViewSortEventArgs e)
    {
        dtEnquiries.DefaultView.Sort = e.SortExpression + " " + SortDir(e.SortExpression);
        gv.DataSource = dtEnquiries;
        gv.DataBind();
    }

    private string SortDir(string sField)
    {
        string sDir = "asc";
        string sPrevField = (ViewState["SortField"] != null ? ViewState["SortField"].ToString() : "");
        if (sPrevField == sField)
            sDir = (ViewState["SortDir"].ToString() == "asc" ? "desc" : "asc");
        else
            ViewState["SortField"] = sField;

        ViewState["SortDir"] = sDir;
        return sDir;
    }
#endregion grid view

}