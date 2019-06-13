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

public partial class ACategoryEdit : System.Web.UI.Page
{
    ADAL.ADAL cobj = new ADAL.ADAL();
    HttpCookie cultureCookie;
    public static DataTable dtTypes;
    public static DataTable dtCategory;
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            if(Request.QueryString["c"]!=null)
            {
                lblcid.Text =cobj.Decrypt(Request.QueryString["c"].ToString().Trim());
                LoadTypes();
                LoadCategory();
            }
           
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
        Category pobj = new Category();
        pobj.CType = "sone";
        pobj.CategoryId = lblcid.Text.Trim();
        dtCategory = cobj.GetCategory(pobj);
        if(dtCategory.Rows.Count>0)
        {
            txtCategoryName.Text = dtCategory.Rows[0]["CategoryName"].ToString().Trim();
            txtCategoryName1.Text = dtCategory.Rows[0]["CategoryName1"].ToString().Trim();
            string TypesId= dtCategory.Rows[0]["TypesId"].ToString().Trim();
            if(TypesId!="")
            {
                ddlTypes.Text = TypesId;
            }
        }
    }

    protected void lbtnUpdate_Click(object sender, EventArgs e)
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
                string CategoryId = lblcid.Text.Trim();
                string CName = txtCategoryName.Text.Trim();
                string CName1 = txtCategoryName1.Text.Trim();
                string TypesId = ddlTypes.SelectedValue.ToString().Trim();
                Category pobj = new Category();
                pobj.CType = "update";
                pobj.CategoryId = CategoryId;
                pobj.TypesId = TypesId;
                pobj.CategoryName = CName;
                pobj.CategoryName1 = CName1;
               cobj.ProcCategory(pobj);
                lbler.Text = "Category has been updated";
            }
            else
            {
                Response.Redirect("Default.aspx");
            }
        }
    }

    protected void lbtnDelete_Click(object sender, EventArgs e)
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
                string CategoryId = lblcid.Text.Trim();
                Category pobj = new Category();
                pobj.CType = "delete";
                pobj.CategoryId = CategoryId;
                cobj.ProcCategory(pobj);
                lbler.Text = "Category has been deleted";
            }
            else
            {
                Response.Redirect("Default.aspx");
            }
        }
    }


}