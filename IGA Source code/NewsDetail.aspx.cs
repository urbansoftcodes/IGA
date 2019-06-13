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
using System.Web.UI.HtmlControls;
using ADAL;
using ABLL;
public partial class NewsDetail : System.Web.UI.Page
{
    HttpCookie cultureCookie;
    public static DataSet ds;
    public static DataTable dtCategory;
    public static DataTable dtImages;
    ADAL.ADAL cobj = new ADAL.ADAL();
    static string tid = System.Configuration.ConfigurationSettings.AppSettings["news"].ToString().Trim();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //if (Request.QueryString["c"] != null)
            if (Session["news"] != null)
            {
                //lblpid.Text = Request.QueryString["c"].ToString().Trim();
                lblpid.Text = Session["news"].ToString().Trim();
                LoadLang();
               
            }
           
        }
        
    }
   

    public void LoadLang()
    {
        cultureCookie = Request.Cookies["Culture"];
        string cultureCode = (cultureCookie != null) ? cultureCookie.Value : null;
        string a = lblpid.Text.Trim();
        Contents caobj = new Contents();
        Contents caobju = new Contents();
        caobju.ContentId = a;
        caobj.CType = "sone";
        caobj.ContentId = a;
        DataTable dtc = cobj.GetContents(caobj);
        string CTitle = "";
        string CShort = "";
        string CType = "";
        string CCat = "";
        string CPrice = "";
        string CDet = "";
        string CView = "";
        Types caobj1 = new Types();
        caobj1.CType = "sone";
        Category caobj2 = new Category();
        caobj2.CType = "sone";
        DataTable dtct = new DataTable();
        DataTable dtca = new DataTable();
        if (dtc.Rows.Count > 0)
        {
            CPrice = dtc.Rows[0]["Price"].ToString().Trim();
            string tid = dtc.Rows[0]["TypesId"].ToString().Trim();
            string cid = dtc.Rows[0]["CategoryId"].ToString().Trim();
            string cdate= dtc.Rows[0]["PublishDate"].ToString().Trim();
            if(cdate!="")
            {
                lblDate.Text = Convert.ToDateTime(cdate).ToShortDateString();
            }
            
            CTitle = dtc.Rows[0]["ContentTitle"].ToString().Trim();
            CTitle = dtc.Rows[0]["ContentTitle"].ToString().Trim();
            caobj1.TypesId = tid;
            caobj2.CategoryId = cid;
            dtct = cobj.GetTypes(caobj1);
            dtca = cobj.GetCategory(caobj2);
            string dimg = dtc.Rows[0]["DImage"].ToString().Trim();
            if(dimg!="")
            {
                imgd.ImageUrl = dimg;
                imgd.Visible = true;
                
            }
            else
            {
                imgd.Visible = false;
            }
        }
        switch (cultureCode)
        {
            case "L2":
               caobju.CType = "updateview1";
                if (dtc.Rows.Count>0)
                {
                    CTitle = dtc.Rows[0]["ContentTitle1"].ToString().Trim();
                    CShort = dtc.Rows[0]["ShortContent1"].ToString().Trim();
                    CDet = dtc.Rows[0]["ContentDetail1"].ToString().Trim();
                    CView = dtc.Rows[0]["TotalViews1"].ToString().Trim();

                }
                if (dtct.Rows.Count > 0)
                {
                    CType= dtct.Rows[0]["TypesName1"].ToString().Trim();
                }
                if (dtca.Rows.Count > 0)
                {
                    CCat = dtca.Rows[0]["CategoryName1"].ToString().Trim();
                }
                
                
                break;
            case "L1":
                caobju.CType = "updateview";
                if (dtc.Rows.Count > 0)
                {
                    CTitle = dtc.Rows[0]["ContentTitle"].ToString().Trim();
                    CShort = dtc.Rows[0]["ShortContent"].ToString().Trim();
                    CDet = dtc.Rows[0]["ContentDetail"].ToString().Trim();
                    CView = dtc.Rows[0]["TotalViews"].ToString().Trim();
                }
                if (dtct.Rows.Count > 0)
                {
                    CType = dtct.Rows[0]["TypesName"].ToString().Trim();
                }
               
                
                break;
            default:
                caobju.CType = "updateview";
                if (dtc.Rows.Count > 0)
                {
                    CTitle = dtc.Rows[0]["ContentTitle"].ToString().Trim();
                    CShort = dtc.Rows[0]["ShortContent"].ToString().Trim();
                    CDet = dtc.Rows[0]["ContentDetail"].ToString().Trim();
                    CView = dtc.Rows[0]["TotalViews"].ToString().Trim();
                }
                if (dtct.Rows.Count > 0)
                {
                    CType = dtct.Rows[0]["TypesName"].ToString().Trim();
                }
               

               
                break;
        }
        cobj.ProcContents(caobju);
        lblTitle.Text = CTitle;
        
        lblDes1.Text = CDet;
        lblType.Text = CType;
        lblType1.Text = CType;
        lblType2.Text = CType;

        if (CView!="")
        {
            lblViews.Text = (Convert.ToInt64(CView) + 1).ToString();
        }

       



        //Add Page Title
        this.Page.Title = CTitle;
       

    }

   

   
}