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
public partial class ACategory : System.Web.UI.Page
{
    ADAL.ADAL cobj = new ADAL.ADAL();
    HttpCookie cultureCookie;
    public static DataTable dtTypes;
    public static DataTable dtCategory;
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            LoadTypes();
            LoadCategory();
           
        }
    }
    public void LoadTypes()
    {
        Types sobj = new Types();
        sobj.CType = "sall";
        dtTypes = cobj.GetTypes(sobj);
        ddlTypes.Items.Clear();
        ddlTypes.DataSource = dtTypes;
        ddlTypes.DataValueField = "TypesId";
        ddlTypes.DataTextField = "TypesName";
        ddlTypes.Items.Insert(0, new ListItem("", ""));
        ddlTypes.DataBind();
    }
    protected void ddlTypes_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadCategory();
    }
    protected void lbtnAddNew_Click(object sender, EventArgs e)
    {
        if (Request.Cookies["csrf"] == null || Request.Cookies["csrf"].ToString().Trim() == "")
        {
            Response.Redirect("Default.aspx");
        }
        else
        {

            cultureCookie = Request.Cookies["csrf"];
            string csrt = cultureCookie.Value;
            amain master = (amain)this.Master;
            Label lcsrt = (Label)master.FindControl("lblhcsrf");
            string hcsrt = lcsrt.Text.Trim();
            if (csrt == hcsrt)
            {
              string CategoryId = cobj.GetID("Category");
                Category pobj = new Category();
                pobj.CType = "insert";
                pobj.CategoryId = CategoryId;
                cobj.ProcCategory(pobj);
                Response.Redirect("ACategoryEdit.aspx?c=" + cobj.Encrypt(CategoryId));
                
            }
            else
            {
                Response.Redirect("Default.aspx");
            }
        }
    }

    public void LoadCategory()
    {
        Category pobj = new Category();
        string a = ddlTypes.SelectedValue.ToString().Trim();
        if (a == "")
        {
            pobj.CType = "sall";
        }
        else
        {
            pobj.CType = "sbytype";
            pobj.TypesId = a;
        }
       
        dtCategory = cobj.GetCategory(pobj);
        gv.DataSource = dtCategory;
        gv.DataBind();
    }

    protected void lbtnEdit_Click(object sender, EventArgs e)
    {
        using (GridViewRow row = (GridViewRow)((LinkButton)sender).Parent.Parent)
        {
            string sid = (row.FindControl("lblveid") as Label).Text.Trim();
            Response.Redirect("ACategoryEdit.aspx?c=" + cobj.Encrypt(sid));
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
        LoadCategory(); //bindgridview will get the data source and bind it again
    }


    protected void gv_Sorting(object sender, GridViewSortEventArgs e)
    {
        dtCategory.DefaultView.Sort = e.SortExpression + " " + SortDir(e.SortExpression);
        gv.DataSource = dtCategory;
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