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
public partial class SpeakerDetail : System.Web.UI.Page
{
    HttpCookie cultureCookie;
    public static DataSet ds;
    public static DataTable dtCategory;
    ADAL.ADAL cobj = new ADAL.ADAL();
    static string tspeakers2018 = System.Configuration.ConfigurationSettings.AppSettings["speakers2018"].ToString().Trim();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadData();
        }
    }
    public void LoadData()
    {
        //if(Request.QueryString["c"]!=null)
       if (Session["speakerdetail"] != null)
        {
           // string a = Request.QueryString["c"].ToString().Trim();
           string a = Session["speakerdetail"].ToString().Trim();
            Contents cobj1 = new Contents();
            cobj1.CType = "sone";
            cobj1.ContentId = a;
            DataTable dt = cobj.GetContents(cobj1);
            if(dt.Rows.Count>0)
            {


                cultureCookie = Request.Cookies["Culture"];
                string cultureCode = (cultureCookie != null) ? cultureCookie.Value : null;

                switch (cultureCode)
                {
                    case "L2":
                        
                        lblType.Text = dt.Rows[0]["TypesName1"].ToString().Trim();
                        lblType1.Text = dt.Rows[0]["TypesName1"].ToString().Trim();
                        lblCat.Text = dt.Rows[0]["CategoryName1"].ToString().Trim();
                        imgd.ImageUrl = dt.Rows[0]["DImage"].ToString().Trim();
                        lblTitle.Text = dt.Rows[0]["ContentTitle1"].ToString().Trim();
                        lblShort.Text = dt.Rows[0]["ShortContent1"].ToString().Trim();
                        lblMore.Text = dt.Rows[0]["ADetail1"].ToString().Trim();
                        cdet.InnerHtml = dt.Rows[0]["ContentDetail1"].ToString().Trim();

                        break;
                    case "L1":

                        lblType.Text = dt.Rows[0]["TypesName"].ToString().Trim();
                        lblType1.Text = dt.Rows[0]["TypesName"].ToString().Trim();
                        lblCat.Text = dt.Rows[0]["CategoryName"].ToString().Trim();
                        imgd.ImageUrl = dt.Rows[0]["DImage"].ToString().Trim();
                        lblTitle.Text = dt.Rows[0]["ContentTitle"].ToString().Trim();
                        lblShort.Text = dt.Rows[0]["ShortContent"].ToString().Trim();
                        lblMore.Text = dt.Rows[0]["ADetail"].ToString().Trim();
                        cdet.InnerHtml = dt.Rows[0]["ContentDetail"].ToString().Trim();

                        break;
                    default:
                        lblType.Text = dt.Rows[0]["TypesName"].ToString().Trim();
                        lblType1.Text = dt.Rows[0]["TypesName"].ToString().Trim();
                        lblCat.Text = dt.Rows[0]["CategoryName"].ToString().Trim();
                        imgd.ImageUrl = dt.Rows[0]["DImage"].ToString().Trim();
                        lblTitle.Text = dt.Rows[0]["ContentTitle"].ToString().Trim();
                        lblShort.Text = dt.Rows[0]["ShortContent"].ToString().Trim();
                        lblMore.Text = dt.Rows[0]["ADetail"].ToString().Trim();
                        cdet.InnerHtml = dt.Rows[0]["ContentDetail"].ToString().Trim();
                        break;
                }
            }

        }
    }


    protected void lblType_Click(object sender, EventArgs e)
    {
        Session["speakers"] = tspeakers2018;
        Response.Redirect("Speakers.aspx");
    }
}