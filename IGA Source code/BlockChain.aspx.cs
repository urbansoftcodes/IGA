using ABLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default3 : System.Web.UI.Page
{
    HttpCookie cultureCookie;
    ADAL.ADAL cobj = new ADAL.ADAL();
    public static DataTable dtContent;
    static string tabout = System.Configuration.ConfigurationSettings.AppSettings["topics"].ToString().Trim();
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
        Session["topics"] = "SC3";
        //if(Request.QueryString["c"]!=null)
        if (Session["topics"] != null || Request.QueryString["c"] != null)
        {
            string catid = "";
            if (Session["topics"] != null)
            {
                catid = Session["topics"].ToString().Trim();
            }
            else if (Request.QueryString["c"] != null)
            {
                catid = Request.QueryString["c"].ToString().Trim();
            }

            Contents tobj = new Contents();
            tobj.CType = "sbycata";
            tobj.TypesId = tabout;
            //tobj.CategoryId = Request.QueryString["c"].ToString().Trim();
            tobj.CategoryId = catid;
            dtContent = cobj.GetContents(tobj);
            if (dtContent.Rows.Count > 0)
            {

                switch (cultureCode)
                {
                    case "L2":

                        aaus.InnerHtml = dtContent.Rows[0]["ContentDetail1"].ToString().Trim();
                        break;
                    case "L1":

                        aaus.InnerHtml = dtContent.Rows[0]["ContentDetail"].ToString().Trim();
                        break;
                    default:

                        aaus.InnerHtml = dtContent.Rows[0]["ContentDetail"].ToString().Trim();
                        break;
                }
            }
        }

    }
}