using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default3 : System.Web.UI.Page
{
    ADAL.ADAL cobj = new ADAL.ADAL();
    RDAL rdal = new RDAL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            loadHomeBanners();
        }
    }

    public void loadHomeBanners()
    {
        DataTable dt = rdal.FetchHomeBanners();
        gv.DataSource = dt;
        gv.DataBind();
    }
    protected void lbtnEdit_Click(object sender, EventArgs e)
    {
        using (GridViewRow row = (GridViewRow)((LinkButton)sender).Parent.Parent)
        {
            string sid = (row.FindControl("lblveid") as Label).Text.Trim();
            Response.Redirect("AHomeBannerEdit.aspx?c=" + cobj.Encrypt(sid));
        }
    }

    protected void gv_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gv.PageIndex = e.NewPageIndex;
       // LoadCategory(); //bindgridview will get the data source and bind it again
    }


    protected void gv_Sorting(object sender, GridViewSortEventArgs e)
    {
        //dtCategory.DefaultView.Sort = e.SortExpression + " " + SortDir(e.SortExpression);
        //gv.DataSource = dtCategory;
        //gv.DataBind();
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
    protected void lbtnAddNew_Click(object sender, EventArgs e)
    {
        Response.Redirect("AHomeBannerEdit.aspx");
    }
    protected void lbtnDelete_Click(object sender, EventArgs e)
    {
        using (GridViewRow row = (GridViewRow)((LinkButton)sender).Parent.Parent)
        {
            string sid = (row.FindControl("lblveid") as Label).Text.Trim();
            HomeBanners_Mob banner = new HomeBanners_Mob();
            int bannerid = string.IsNullOrEmpty(sid) ? 0 : Convert.ToInt32(sid);
            banner.HomeBannerID = bannerid;
            banner.Type = "Delete";
            rdal.PostHomeBanners(banner);
            loadHomeBanners();
        }
    }
}