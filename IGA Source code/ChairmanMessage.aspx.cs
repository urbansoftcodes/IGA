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
    static string tabout = System.Configuration.ConfigurationSettings.AppSettings["about"].ToString().Trim();
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
       Session["about"] = "SC29";
        //if(Request.QueryString["c"]!=null)
        if (Session["about"] != null)
        {

            Contents tobj = new Contents();
            tobj.CType = "sbycata";
            tobj.TypesId = tabout;
            //tobj.CategoryId = Request.QueryString["c"].ToString().Trim();
            tobj.CategoryId = Session["about"].ToString().Trim();
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