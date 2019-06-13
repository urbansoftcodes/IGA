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

public partial class ATypesEdit : System.Web.UI.Page
{
    ADAL.ADAL cobj = new ADAL.ADAL();
    HttpCookie cultureCookie;
    public static DataTable dtTypes;
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            if(Request.QueryString["c"]!=null)
            {
                lblcid.Text =cobj.Decrypt(Request.QueryString["c"].ToString().Trim());
                LoadProduct();
            }
           
        }
    }

    public void LoadProduct()
    {
        Types pobj = new Types();
        pobj.CType = "sone";
        pobj.TypesId = lblcid.Text.Trim();
        dtTypes = cobj.GetTypes(pobj);
        if(dtTypes.Rows.Count>0)
        {
            txtTypesName.Text = dtTypes.Rows[0]["TypesName"].ToString().Trim();
            txtTypesName1.Text = dtTypes.Rows[0]["TypesName1"].ToString().Trim();
            
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
                string TypesId = lblcid.Text.Trim();
                string TName = txtTypesName.Text.Trim();
                string TName1 = txtTypesName1.Text.Trim();
               
                Types pobj = new Types();
                pobj.CType = "update";
                pobj.TypesId = TypesId;
                pobj.TypesName = TName;
                pobj.TypesName1 = TName1;
               cobj.ProcTypes(pobj);
                lbler.Text = "Types has been updated";
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
                string TypesId = lblcid.Text.Trim();
                Types pobj = new Types();
                pobj.CType = "delete";
                pobj.TypesId = TypesId;
                cobj.ProcTypes(pobj);
                lbler.Text = "Types has been deleted";
            }
            else
            {
                Response.Redirect("Default.aspx");
            }
        }
    }


}