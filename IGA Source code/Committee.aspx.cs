using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Reflection;
using System.Resources;
using System.Globalization;
using System.Security.Principal;
using System.Web.Services;
using System.IO;
using ADAL;
using ABLL;
using System.Web.UI.HtmlControls;
public partial class Committee : System.Web.UI.Page
{
    HttpCookie cultureCookie;
    ADAL.ADAL cobj = new ADAL.ADAL();
    public static DataTable dtLatest;
    public static DataTable dtTypes;
    static string tabout = System.Configuration.ConfigurationSettings.AppSettings["committee"].ToString().Trim();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadLang1();
            LoadLatest();

        }
    }
    public void LoadLang1()
    {
        cultureCookie = Request.Cookies["Culture"];
        string cultureCode = (cultureCookie != null) ? cultureCookie.Value : null;

        Types tobj = new Types();
        tobj.CType = "sone";
        tobj.TypesId = tabout;
        dtTypes = cobj.GetTypes(tobj);
        if (dtTypes.Rows.Count>0)
        {
      
        switch (cultureCode)
        {
            case "L2":

                   lblAgenda.Text= dtTypes.Rows[0]["TypesName1"].ToString().Trim();
                    lblAgenda1.Text = dtTypes.Rows[0]["TypesName1"].ToString().Trim();
                   // lblAgenda2.Text = dtTypes.Rows[0]["TypesName1"].ToString().Trim();
                    break;
            case "L1":
                    lblAgenda.Text = dtTypes.Rows[0]["TypesName"].ToString().Trim();
                    lblAgenda1.Text = dtTypes.Rows[0]["TypesName"].ToString().Trim();
                   // lblAgenda2.Text = dtTypes.Rows[0]["TypesName"].ToString().Trim();
                    break;
            default:
                    lblAgenda.Text = dtTypes.Rows[0]["TypesName"].ToString().Trim();
                    lblAgenda1.Text = dtTypes.Rows[0]["TypesName"].ToString().Trim();
                   // lblAgenda2.Text = dtTypes.Rows[0]["TypesName"].ToString().Trim();
                    break;
        }
        }


    }

    public void LoadLatest()
    {
        Category aobj = new Category();
        aobj.TypesId = tabout;
        aobj.CType = "sbytype";
        dtLatest = cobj.GetCategory(aobj);

        // dlLatest.DataSource = dtLatest;
        // dlLatest.DataBind();



        DataTable dtMarks1 = dtLatest.Clone();
        dtMarks1.Columns["CreatedDate"].DataType = Type.GetType("System.DateTime");

        foreach (DataRow dr in dtLatest.Rows)
        {
            dtMarks1.ImportRow(dr);
        }
        dtMarks1.AcceptChanges();


        DataView dv = dtMarks1.DefaultView;
        dv.Sort = "CreatedDate ASC";

        dlLatest.DataSource = dv;
        dlLatest.DataBind();





    }

    protected void dlLatest_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item ||
           e.Item.ItemType == ListItemType.AlternatingItem)
        {


            Label lbtit = (Label)e.Item.FindControl("lblTitle");
            Label lbtit1 = (Label)e.Item.FindControl("lblTitle1");

            Label lbid = (Label)e.Item.FindControl("lblCategoryId");

            Repeater dlLat = (Repeater)e.Item.FindControl("dlLatest1");

            Contents aobj1 = new Contents();
            aobj1.TypesId = tabout;
            aobj1.CType = "sbycata";
            aobj1.CategoryId = lbid.Text.Trim();
            DataTable dtLatest1 = cobj.GetContents(aobj1);

            dlLat.DataSource = dtLatest1;
            dlLat.DataBind();


            cultureCookie = Request.Cookies["Culture"];
            string cultureCode = (cultureCookie != null) ? cultureCookie.Value : null;

            switch (cultureCode)
            {
                case "L2":
                    lbtit.Visible = false;
                    lbtit1.Visible = true;


                    break;
                case "L1":
                    lbtit.Visible = true;
                    lbtit1.Visible = false;


                    break;
                default:
                    lbtit.Visible = true;
                    lbtit1.Visible = false;


                    break;
            }




        }
    }

    protected void dlLatest1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item ||
           e.Item.ItemType == ListItemType.AlternatingItem)
        {


            Label lbtit = (Label)e.Item.FindControl("lblTitle");
            Label lbtit1 = (Label)e.Item.FindControl("lblTitle1");
            Label lbsho = (Label)e.Item.FindControl("lblShort");
            Label lbsho1 = (Label)e.Item.FindControl("lblShort1");
            //Label lblc = (Label)e.Item.FindControl("lblCategoryId");
            //Label lbadr = (Label)e.Item.FindControl("lblView");


            //HtmlControl hc = (HtmlControl)e.Item.FindControl("slcss");
            //if (lblc.Text.Trim() == "1")
            //{
            //    hc.Attributes["class"] = "item active";

            //}
            //else
            //{
            //    hc.Attributes["class"] = "item";
            //}


            cultureCookie = Request.Cookies["Culture"];
            string cultureCode = (cultureCookie != null) ? cultureCookie.Value : null;

            switch (cultureCode)
            {
                case "L2":
                    lbtit.Visible = false;
                    lbtit1.Visible = true;

                    lbsho.Visible = false;
                    lbsho1.Visible = true;


                   // lbadr.Text = HttpContext.GetGlobalResourceObject("Lang", "ReadMore").ToString();
                    break;
                case "L1":
                    lbtit.Visible = true;
                    lbtit1.Visible = false;

                    lbsho.Visible = true;
                    lbsho1.Visible = false;



                   // lbadr.Text = HttpContext.GetGlobalResourceObject("English", "ReadMore").ToString();

                    break;
                default:
                    lbtit.Visible = true;
                    lbtit1.Visible = false;

                    lbsho.Visible = true;
                    lbsho1.Visible = false;

                   // lbadr.Text = HttpContext.GetGlobalResourceObject("English", "ReadMore").ToString();

                    break;
            }




        }
    }



}