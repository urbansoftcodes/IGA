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
public partial class Speakers : System.Web.UI.Page
{
    HttpCookie cultureCookie;
    ADAL.ADAL cobj = new ADAL.ADAL();
    public static DataTable dtContent;
    static string tspeakers2018 = System.Configuration.ConfigurationSettings.AppSettings["speakers2018"].ToString().Trim();

    static string tabout = System.Configuration.ConfigurationSettings.AppSettings["speakers"].ToString().Trim();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadLang1();

        }
    }
    public void LoadLang1()
    {
        cultureCookie = Request.Cookies["Culture"];
        string cultureCode = (cultureCookie != null) ? cultureCookie.Value : null;
        //if (Request.QueryString["c"] != null)
        string catid = "";
        if (Session["speakers"] != null)
        {
            catid= Session["speakers"].ToString().Trim();
        }
        else
        {
            catid = tspeakers2018;
        }
        Contents tobj = new Contents();
            tobj.CType = "sbycata";
            tobj.TypesId = tabout;
        // tobj.CategoryId = Request.QueryString["c"].ToString().Trim();
        tobj.CategoryId = catid;
            dtContent = cobj.GetContents(tobj);

        

            DataTable dtMarks1 = dtContent.Clone();
            dtMarks1.Columns["Price"].DataType = Type.GetType("System.Int32");

            foreach (DataRow dr in dtContent.Rows)
            {
                dtMarks1.ImportRow(dr);
            }
            dtMarks1.AcceptChanges();


            DataView dv = dtMarks1.DefaultView;
            dv.Sort = "Price ASC";

            

            dlCont.DataSource = dv;
            dlCont.DataBind();
        
        //if (Request.QueryString["t"] != null)
        //{
        //    lblYSpeakers.Text = Request.QueryString["t"].ToString().Trim();
        //    lblYSpeakers2.Text = Request.QueryString["t"].ToString().Trim();
        //}


        switch (cultureCode)
        {
            case "L2":
                //lblPSpeakers.Text = HttpContext.GetGlobalResourceObject("lang", "YSpeakers").ToString();
                //lblPSpeakers1.Text = HttpContext.GetGlobalResourceObject("lang", "PSpeakers").ToString();
                //lblPSpeakers2.Text = HttpContext.GetGlobalResourceObject("lang", "YSpeakers").ToString();
                //lblSpeakers.Text = HttpContext.GetGlobalResourceObject("lang", "Speakers").ToString();

                //lblPSpeakers.Text = "2018 متحدثين";
                //lblPSpeakers1.Text = "2018 متحدثين";
                //lblPSpeakers2.Text = "2018 متحدثين";

                lblPSpeakers.Text = HttpContext.GetGlobalResourceObject("lang", "Speakers").ToString();
               // lblPSpeakers1.Text = HttpContext.GetGlobalResourceObject("lang", "Speakers").ToString();
                lblPSpeakers2.Text = HttpContext.GetGlobalResourceObject("lang", "Speakers").ToString();

                lblSpeakers.Text = HttpContext.GetGlobalResourceObject("lang", "Speakers").ToString();
                break;
            case "L1":
                //lblPSpeakers.Text = HttpContext.GetGlobalResourceObject("English", "YSpeakers").ToString();
                //lblPSpeakers1.Text = HttpContext.GetGlobalResourceObject("English", "PSpeakers").ToString();
                //lblPSpeakers2.Text = HttpContext.GetGlobalResourceObject("English", "YSpeakers").ToString();
                //lblSpeakers.Text = HttpContext.GetGlobalResourceObject("English", "Speakers").ToString();
                //lblPSpeakers.Text = "2018 Speakers";
                //lblPSpeakers1.Text = "2018 Speakers";
                //lblPSpeakers2.Text = "2018 Speakers";
                lblPSpeakers.Text = HttpContext.GetGlobalResourceObject("English", "Speakers").ToString();
               // lblPSpeakers1.Text = HttpContext.GetGlobalResourceObject("English", "Speakers").ToString();
                lblPSpeakers2.Text = HttpContext.GetGlobalResourceObject("English", "Speakers").ToString();
                lblSpeakers.Text = HttpContext.GetGlobalResourceObject("English", "Speakers").ToString();
                break;
            default:
                //lblPSpeakers.Text = HttpContext.GetGlobalResourceObject("English", "YSpeakers").ToString();
                //lblPSpeakers1.Text = HttpContext.GetGlobalResourceObject("English", "PSpeakers").ToString();
                //lblPSpeakers2.Text = HttpContext.GetGlobalResourceObject("English", "YSpeakers").ToString();
                //lblSpeakers.Text = HttpContext.GetGlobalResourceObject("English", "Speakers").ToString();
                //lblPSpeakers.Text = "2018 Speakers";
                //lblPSpeakers1.Text = "2018 Speakers";
                //lblPSpeakers2.Text = "2018 Speakers";
                lblPSpeakers.Text = HttpContext.GetGlobalResourceObject("English", "Speakers").ToString();
               // lblPSpeakers1.Text = HttpContext.GetGlobalResourceObject("English", "Speakers").ToString();
                lblPSpeakers2.Text = HttpContext.GetGlobalResourceObject("English", "Speakers").ToString();
                lblSpeakers.Text = HttpContext.GetGlobalResourceObject("English", "Speakers").ToString();
                break;
        }


       

    }


    protected void dlCont_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item ||
            e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Label lbt1 = (Label)e.Item.FindControl("lblCTitle");
            Label lbt1a = (Label)e.Item.FindControl("lblCTitle1");
            Label lbts1 = (Label)e.Item.FindControl("lblShort");
            Label lbts1a = (Label)e.Item.FindControl("lblShort1");
            Label lbtm1 = (Label)e.Item.FindControl("lblDet");
            Label lbtm1a = (Label)e.Item.FindControl("lblDet1");


            cultureCookie = Request.Cookies["Culture"];
            string cultureCode = (cultureCookie != null) ? cultureCookie.Value : null;

            switch (cultureCode)
            {
                case "L2":
                    lbt1.Visible = false;
                    lbt1a.Visible = true;
                    lbts1.Visible = false;
                    lbts1a.Visible = true;
                    lbtm1.Visible = false;
                    lbtm1a.Visible = true;
                    break;
                case "L1":
                    lbt1.Visible = true;
                    lbt1a.Visible = false;
                    lbts1.Visible = true;
                    lbts1a.Visible = false;
                    lbtm1.Visible = true;
                    lbtm1a.Visible = false;
                    break;
                default:
                    lbt1.Visible = true;
                    lbt1a.Visible = false;
                    lbts1.Visible = true;
                    lbts1a.Visible = false;
                    lbtm1.Visible = true;
                    lbtm1a.Visible = false;
                    break;
            }



        }
    }

    protected void dlCont_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        string a = ((Label)e.Item.FindControl("lblCategoryId")).Text.Trim();
        if (e.CommandName == "view")
        {
            Session["speakerdetail"] = a;
            Response.Redirect("SpeakerDetail.aspx");

        }
    }

}