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
public partial class AContents : System.Web.UI.Page
{
    ADAL.ADAL cobj = new ADAL.ADAL();
    HttpCookie cultureCookie;
    public static DataTable dtTypes;
    public static DataTable dtCategory;
    public static DataTable dtSubCategory;
    public static DataTable dtSCategorySub;
    public static DataTable dtContents;
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            LoadTypes();
            LoadCategory();
            LoadSubCategory();
            LoadSCategorySub();
            LoadContents();
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
    public void LoadCategory()
    {
        string a= ddlTypes.SelectedValue.ToString().Trim();
        Category sobj = new Category();
        sobj.CType = "sbytype";
        sobj.TypesId = a;
        dtCategory = cobj.GetCategory(sobj);
        ddlCategory.Items.Clear();
        ddlCategory.DataSource = dtCategory;
        ddlCategory.DataValueField = "CategoryId";
        ddlCategory.DataTextField = "CategoryName";
        ddlCategory.Items.Insert(0, new ListItem("", ""));
        ddlCategory.DataBind();
        LoadSubCategory();
    }

    public void LoadSubCategory()
    {
        string a = ddlCategory.SelectedValue.ToString().Trim();
        SubCategory sobj = new SubCategory();
        sobj.CType = "sbycat";
        sobj.CategoryId = a;
        dtSubCategory = cobj.GetSubCategory(sobj);
        ddlSubCategory.Items.Clear();
        ddlSubCategory.DataSource = dtSubCategory;
        ddlSubCategory.DataValueField = "SubCategoryId";
        ddlSubCategory.DataTextField = "SubCategoryName";
        ddlSubCategory.Items.Insert(0, new ListItem("", ""));
        ddlSubCategory.DataBind();
        LoadSCategorySub();
    }
    public void LoadSCategorySub()
    {
        string a = ddlSubCategory.SelectedValue.ToString().Trim();
        SCategorySub sobj = new SCategorySub();
        sobj.CType = "sbysubcat";
        sobj.SubCategoryId = a;
        dtSCategorySub = cobj.GetSCategorySub(sobj);
        ddlSCategorySub.Items.Clear();
        ddlSCategorySub.DataSource = dtSCategorySub;
        ddlSCategorySub.DataValueField = "SubCategoryId";
        ddlSCategorySub.DataTextField = "SubCategoryName";
        ddlSCategorySub.Items.Insert(0, new ListItem("", ""));
        ddlSCategorySub.DataBind();
        LoadContents();
    }
    protected void ddlTypes_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadCategory();
        LoadSubCategory();
        LoadSCategorySub();
        LoadContents();
    }
    protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadSubCategory();
        LoadSCategorySub();
        LoadContents();
    }
    protected void ddlSubCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadSCategorySub();
        LoadSCategorySub();
        LoadContents();
    }
    protected void ddlSCategorySub_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadContents();
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
              string ContentsId = cobj.GetID("Contents");
                Contents pobj = new Contents();
                pobj.CType = "insert";
                pobj.ContentId = ContentsId;
                cobj.ProcContents(pobj);
                Response.Redirect("AContentsEdit.aspx?c=" + cobj.Encrypt(ContentsId));
                
            }
            else
            {
                Response.Redirect("Default.aspx");
            }
        }
    }

    public void LoadContents()
    {
        Contents pobj = new Contents();
        string a = ddlTypes.SelectedValue.ToString().Trim();
        string b = ddlCategory.SelectedValue.ToString().Trim();
        string c = ddlSubCategory.SelectedValue.ToString().Trim();
        string d = ddlSCategorySub.SelectedValue.ToString().Trim();
        if (a == "")
        {
            pobj.CType = "sall";
        }
        else if (a != "" && b == "" && c == "" && d == "")
        {
            pobj.CType = "sbytype";
            pobj.TypesId = a;
        }
        else if (a != "" && b != "" && c == "" && d == "")
        {
            pobj.CType = "sbycat";
            pobj.TypesId = a;
            pobj.CategoryId = b;
        }
        else if (a != "" && b != "" && c != "" && d == "")
        {
            pobj.CType = "sbysubcat";
            pobj.TypesId = a;
            pobj.CategoryId = b;
            pobj.SubCategoryId = c;
        }
        else if (a != "" && b != "" && c != "" && d != "")
        {
            pobj.CType = "sbysubcat";
            pobj.TypesId = a;
            pobj.CategoryId = b;
            pobj.SubCategoryId = c;
            pobj.SCategorySubId = d;
        }
        dtContents = cobj.GetContents(pobj);
        gv.DataSource = dtContents;
        gv.DataBind();
    }

    protected void lbtnEdit_Click(object sender, EventArgs e)
    {
        using (GridViewRow row = (GridViewRow)((LinkButton)sender).Parent.Parent)
        {
            string sid = (row.FindControl("lblveid") as Label).Text.Trim();
            Response.Redirect("AContentsEdit.aspx?c=" + cobj.Encrypt(sid));
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
        LoadContents(); //bindgridview will get the data source and bind it again
    }


    protected void gv_Sorting(object sender, GridViewSortEventArgs e)
    {
        dtContents.DefaultView.Sort = e.SortExpression + " " + SortDir(e.SortExpression);
        gv.DataSource = dtContents;
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