using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TweetSharp;
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
public partial class hvideo : System.Web.UI.UserControl
{
    HttpCookie cultureCookie;
   
    static string thomefeed = System.Configuration.ConfigurationSettings.AppSettings["homefeed"].ToString().Trim();
    public static DataTable dtContent2;
    ADAL.ADAL cobj = new ADAL.ADAL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            LoadLang();
        }
    }
    public void LoadLang()
    {


        Contents tobj2 = new Contents();
        tobj2.CType = "sbytypea";
        tobj2.TypesId = thomefeed;
        dtContent2 = cobj.GetContents(tobj2);
        string vcont = "";

        cultureCookie = Request.Cookies["Culture"];
        string cultureCode = (cultureCookie != null) ? cultureCookie.Value : null;


        switch (cultureCode)
        {
            case "L2":
               
                lblVTitle.Text = "فيديو";

                if (dtContent2.Rows.Count > 0)
                {
                    vcont = dtContent2.Rows[0]["ADetail1"].ToString().Trim();
                }
                break;
            case "L1":
                
                lblVTitle.Text = "Video";
                if (dtContent2.Rows.Count > 0)
                {
                    vcont = dtContent2.Rows[0]["ADetail"].ToString().Trim();
                }
                break;
            default:
                
                lblVTitle.Text = "Video";
                if (dtContent2.Rows.Count > 0)
                {
                    vcont = dtContent2.Rows[0]["ADetail"].ToString().Trim();
                }
                break;
        }
        string vurl = "";
        string fe = Path.GetExtension(vcont);
        if (fe == ".mp4" || fe == ".ogv" || fe == ".webm")
        {
            vurl = "<video controls><source src='" + vcont + "'></video>";

        }
        else
        {
            vurl = "<iframe src='" + vcont + "'></iframe>";
        }

        hvid.InnerHtml = vurl;

    }
}