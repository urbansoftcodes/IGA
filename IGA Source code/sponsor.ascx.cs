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
using System.Net;
//using System.Net.Mail;
using System.Web.UI.HtmlControls;
using System.Text;
using System.Web.Mail;
using System.IO;
using ADAL;
using ABLL;
public partial class sponsor : System.Web.UI.UserControl
{
    HttpCookie cultureCookie;
    public static DataSet ds;
    public static DataTable dtCategory;
    public static DataTable dtLatest;
    public static DataTable dtLatest1;
    public static DataTable dtLatest2;
    public static DataTable dtView;
    public static DataTable dtVideo;
    public static DataTable dtSlide;
    public static DataTable dtContent;
    public static DataTable dtContent1;
    public static DataTable dtContent2;
    public static DataTable dtContent3;
    ADAL.ADAL cobj = new ADAL.ADAL();
    static string tid = System.Configuration.ConfigurationSettings.AppSettings["sponsors"].ToString().Trim();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadLang();
            LoadLatest();
          
        }
    }


    public void LoadLang()
    {
        cultureCookie = Request.Cookies["Culture"];
        string cultureCode = (cultureCookie != null) ? cultureCookie.Value : null;
        


        switch (cultureCode)
        {
            case "L2":


               lblSponsor.Text = "الرعاة";
                break;
            case "L1":


               lblSponsor.Text = "Sponsors";
                break;
            default:


               lblSponsor.Text = "Sponsors";
                break;
        }
    }

    public void LoadLatest()
    {
        Category aobj = new Category();
        aobj.TypesId = tid;
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

            Repeater dlLat=(Repeater)e.Item.FindControl("dlLatest1");

            Contents aobj1 = new Contents();
            aobj1.TypesId = tid;
            aobj1.CType = "sbycata";
            aobj1.CategoryId = lbid.Text.Trim();
            DataTable dtLatest1 = cobj.GetContents(aobj1);

            DataTable dtMarks1 = dtLatest1.Clone();
            dtMarks1.Columns["Price"].DataType = Type.GetType("System.Int32");

            foreach (DataRow dr in dtLatest1.Rows)
            {
                dtMarks1.ImportRow(dr);
            }
            dtMarks1.AcceptChanges();

            DataView dv = dtMarks1.DefaultView;
            dv.Sort = "Price ASC";
            DataTable dta1 = dv.ToTable();


           // dlLat.DataSource = dtLatest1;
            dlLat.DataSource = dta1;
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


            //Label lbtit = (Label)e.Item.FindControl("lblTitle");
            //Label lbtit1 = (Label)e.Item.FindControl("lblTitle1");
            //Label lbsho = (Label)e.Item.FindControl("lblShort");
            //Label lbsho1 = (Label)e.Item.FindControl("lblShort1");
            Label lblc = (Label)e.Item.FindControl("lblCategoryId");
            //Label lbadr = (Label)e.Item.FindControl("lblView");


            HtmlControl hc = (HtmlControl)e.Item.FindControl("slcss");
            if (lblc.Text.Trim() == "1")
            {
                hc.Attributes["class"] = "item active";

            }
            else
            {
                hc.Attributes["class"] = "item";
            }


            cultureCookie = Request.Cookies["Culture"];
            string cultureCode = (cultureCookie != null) ? cultureCookie.Value : null;

            //switch (cultureCode)
            //{
            //    case "L2":
            //        lbtit.Visible = false;
            //        lbtit1.Visible = true;

            //        lbsho.Visible = false;
            //        lbsho1.Visible = true;


            //        lbadr.Text = HttpContext.GetGlobalResourceObject("Lang", "ReadMore").ToString();
            //        break;
            //    case "L1":
            //        lbtit.Visible = true;
            //        lbtit1.Visible = false;

            //        lbsho.Visible = true;
            //        lbsho1.Visible = false;



            //        lbadr.Text = HttpContext.GetGlobalResourceObject("English", "ReadMore").ToString();

            //        break;
            //    default:
            //        lbtit.Visible = true;
            //        lbtit1.Visible = false;

            //        lbsho.Visible = true;
            //        lbsho1.Visible = false;

            //        lbadr.Text = HttpContext.GetGlobalResourceObject("English", "ReadMore").ToString();

            //        break;
            //}




        }
    }

}