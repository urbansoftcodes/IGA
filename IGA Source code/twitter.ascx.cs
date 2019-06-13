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
public partial class twitter : System.Web.UI.UserControl
{
    HttpCookie cultureCookie;
    public static string _consumerKey = "590AfxEghbSMYQUBxoP8TYHUV"; // Your key
    public static string _consumerSecret = "3KkTj2Sx8PrfU21JF4OojPwsj5UVtlWQyTte6q9RBKySHANpyA"; // Your key  
    public static string _accessToken = "1020658962801324032-VcgkSBbtIkeEostz7k2jYAyY2Eq9XK"; // Your key  
    public static string _accessTokenSecret = "zaRpMKOLZZ31hJL7onOIgdR88dnDPaNqs2dyK9yrVeHNP"; // Your key  
    static string thomefeed = System.Configuration.ConfigurationSettings.AppSettings["homefeed"].ToString().Trim();
    public static DataTable dtContent2;
    ADAL.ADAL cobj = new ADAL.ADAL();
    protected void Page_Load(object sender, EventArgs e)
    {
        LoadLang();
        TwitterService twitterService = new TwitterService(_consumerKey, _consumerSecret);
        twitterService.AuthenticateWith(_accessToken, _accessTokenSecret);

       
       // var tweets_search = twitterService.Search(new SearchOptions { Q = "#eGovForum", Resulttype = TwitterSearchResultType.Popular });
        var tweets_search = twitterService.Search(new SearchOptions { Q = "#eGovernment", Resulttype = TwitterSearchResultType.Popular });
        //Resulttype can be TwitterSearchResultType.Popular or TwitterSearchResultType.Mixed or TwitterSearchResultType.Recent  
        List<TwitterStatus> resultList = new List<TwitterStatus>(tweets_search.Statuses);
            dlLatestTwit.DataSource = resultList;
        dlLatestTwit.DataBind();
       
    }



    public void LoadLang()  
    {


        //Contents tobj2 = new Contents();
        //tobj2.CType = "sbytypea";
        //tobj2.TypesId = thomefeed;
        //dtContent2 = cobj.GetContents(tobj2);
        //string vcont = "";

        cultureCookie = Request.Cookies["Culture"];
        string cultureCode = (cultureCookie != null) ? cultureCookie.Value : null;
       

        switch (cultureCode)
        {
            case "L2":
                lblTitle.Text = "منشورات #eGovForum";
                //lblVTitle.Text = "فيديو";

                //if (dtContent2.Rows.Count > 0)
                //{
                //    vcont=dtContent2.Rows[0]["ADetail1"].ToString().Trim();
                //}
                break;
            case "L1":
                lblTitle.Text = "#eGovForum Feed";
                //lblVTitle.Text = "Video";
                //if (dtContent2.Rows.Count > 0)
                //{
                //    vcont = dtContent2.Rows[0]["ADetail"].ToString().Trim();
                //}
                break;
            default:
                lblTitle.Text = "#eGovForum Feed";
                //lblVTitle.Text = "Video";
                //if (dtContent2.Rows.Count > 0)
                //{
                //    vcont = dtContent2.Rows[0]["ADetail"].ToString().Trim();
                //}
                break;
        }
        //string vurl = "";
        //string fe = Path.GetExtension(vcont);
        //if (fe == ".mp4" || fe == ".ogv" || fe == ".webm")
        //{
        //    vurl = "<video controls><source src='" + vcont + "'></video>";
            
        //}
        //else
        //{
        //    vurl = "<iframe src='" + vcont + "'></iframe>";
        //}

        //hvid.InnerHtml = vurl;

    }


}