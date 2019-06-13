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
public partial class main : System.Web.UI.MasterPage
{
    HttpCookie cultureCookie;
    public string lang;
    ADAL.ADAL cobj = new ADAL.ADAL();
    public static DataTable dtTypes;
    public static DataTable dtSMenu1;
    public static DataTable dtSMenu2;
    public static DataTable dtSpeak;
    static string tabout = System.Configuration.ConfigurationSettings.AppSettings["about"].ToString().Trim();
    static string ttopic = System.Configuration.ConfigurationSettings.AppSettings["topics"].ToString().Trim();
    static string tagenda = System.Configuration.ConfigurationSettings.AppSettings["agenda"].ToString().Trim();
    static string tspeakers = System.Configuration.ConfigurationSettings.AppSettings["speakers"].ToString().Trim();
    static string tspeakers2018 = System.Configuration.ConfigurationSettings.AppSettings["speakers2018"].ToString().Trim();
    static string tnews = System.Configuration.ConfigurationSettings.AppSettings["news"].ToString().Trim();
    static string tphoto = System.Configuration.ConfigurationSettings.AppSettings["photo"].ToString().Trim();
    static string tvideo = System.Configuration.ConfigurationSettings.AppSettings["video"].ToString().Trim();
    static string tcontact = System.Configuration.ConfigurationSettings.AppSettings["contact"].ToString().Trim();
    static string tcommitteemenu = System.Configuration.ConfigurationSettings.AppSettings["committeemenu"].ToString().Trim();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadLang();
            loadsmenu();

        }
    }

    protected void lbtnHome_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }

    public void LoadLang()
    {
        Types tobj = new Types();
        tobj.CType = "sall";
        dtTypes = cobj.GetTypes(tobj);

        DataRow[] rabout = dtTypes.Select("TypesId='" + tabout + "'");
        DataRow[] rtopic = dtTypes.Select("TypesId='" + ttopic + "'");
        DataRow[] ragenda = dtTypes.Select("TypesId='" + tagenda + "'");
        DataRow[] rspeakers = dtTypes.Select("TypesId='" + tspeakers + "'");

        DataRow[] rnews = dtTypes.Select("TypesId='" + tnews + "'");
        DataRow[] rphoto = dtTypes.Select("TypesId='" + tphoto + "'");
        DataRow[] rvideo = dtTypes.Select("TypesId='" + tvideo + "'");
        DataRow[] rcontact = dtTypes.Select("TypesId='" + tcontact + "'");

        cultureCookie = Request.Cookies["Culture"];
        string cultureCode = (cultureCookie != null) ? cultureCookie.Value : null;

        switch (cultureCode)
        {
            case "L2":
                fslide.InnerHtml = "<script src='assets/js/jquery.flexslider-ar.js'></script>";
                //mcount.InnerHtml = "<script src='assets/js/soon-ar.js'></script>";
                arcss.Href = "assets/css/arabic.css";
                lbtnAbout.Text = rabout[0]["TypesName1"].ToString().Trim();
                lbtnTopics.Text = rtopic[0]["TypesName1"].ToString().Trim();
                lbtnAgenda.Text = ragenda[0]["TypesName1"].ToString().Trim();
                lbtnSpeakers.Text = rspeakers[0]["TypesName1"].ToString().Trim();
                fcont.InnerHtml = File.ReadAllText(Server.MapPath("aconf/footer1.html"));
                // lblPForum.Text = HttpContext.GetGlobalResourceObject("Lang", "PForum").ToString();
                // lblYear.Text = HttpContext.GetGlobalResourceObject("Lang", "Year").ToString();
                //lbtnContact.Text = HttpContext.GetGlobalResourceObject("Lang", "Year").ToString();
                lbtnLang.Text = HttpContext.GetGlobalResourceObject("English", "Language").ToString();
                // lbtn2018.Text = HttpContext.GetGlobalResourceObject("Lang", "Y2018").ToString();
                // lbtnPSpeakers.Text = HttpContext.GetGlobalResourceObject("Lang", "PSpeakers").ToString();
                imgLogo.ImageUrl = HttpContext.GetGlobalResourceObject("Lang", "Logo").ToString();
                lbtnMedia.Text = HttpContext.GetGlobalResourceObject("Lang", "Media").ToString();

                lbtnNews.Text = rnews[0]["TypesName1"].ToString().Trim();
                lbtnPhoto.Text = rphoto[0]["TypesName1"].ToString().Trim();
                lbtnVideo.Text = rvideo[0]["TypesName1"].ToString().Trim();
                lbtnContact.Text = rcontact[0]["TypesName1"].ToString().Trim();
                txtSearch.Attributes.Add("placeholder", "بحث");
                break;
            case "L1":
                fslide.InnerHtml = "<script src='assets/js/jquery.flexslider.js'></script>";
                // mcount.InnerHtml = "<script src='assets/js/soon.js'></script>";
                arcss.Href = "";
                lbtnAbout.Text = rabout[0]["TypesName"].ToString().Trim();
                lbtnTopics.Text = rtopic[0]["TypesName"].ToString().Trim();
                lbtnAgenda.Text = ragenda[0]["TypesName"].ToString().Trim();
                lbtnSpeakers.Text = rspeakers[0]["TypesName"].ToString().Trim();
                fcont.InnerHtml = File.ReadAllText(Server.MapPath("aconf/footer.html"));
                // lblPForum.Text = HttpContext.GetGlobalResourceObject("English", "PForum").ToString();
                //lblYear.Text = HttpContext.GetGlobalResourceObject("English", "Year").ToString();
                //lbtnContact.Text = HttpContext.GetGlobalResourceObject("English", "Contact").ToString();
                lbtnLang.Text = HttpContext.GetGlobalResourceObject("Lang", "Language").ToString();
                // lbtn2018.Text = HttpContext.GetGlobalResourceObject("English", "Y2018").ToString();
                //lbtnPSpeakers.Text = HttpContext.GetGlobalResourceObject("English", "PSpeakers").ToString();
                imgLogo.ImageUrl = HttpContext.GetGlobalResourceObject("English", "Logo").ToString();
                lbtnMedia.Text = HttpContext.GetGlobalResourceObject("English", "Media").ToString();

                lbtnNews.Text = rnews[0]["TypesName"].ToString().Trim();
                lbtnPhoto.Text = rphoto[0]["TypesName"].ToString().Trim();
                lbtnVideo.Text = rvideo[0]["TypesName"].ToString().Trim();
                lbtnContact.Text = rcontact[0]["TypesName"].ToString().Trim();
                txtSearch.Attributes.Add("placeholder", "search");

                break;
            default:
                fslide.InnerHtml = "<script src='assets/js/jquery.flexslider.js'></script>";
                // mcount.InnerHtml = "<script src='assets/js/soon.js'></script>";
                arcss.Href = "";
                lbtnAbout.Text = rabout[0]["TypesName"].ToString().Trim();
                lbtnTopics.Text = rtopic[0]["TypesName"].ToString().Trim();
                lbtnAgenda.Text = ragenda[0]["TypesName"].ToString().Trim();
                lbtnSpeakers.Text = rspeakers[0]["TypesName"].ToString().Trim();
                fcont.InnerHtml = File.ReadAllText(Server.MapPath("aconf/footer.html"));
                //lblPForum.Text = HttpContext.GetGlobalResourceObject("English", "PForum").ToString();
                // lblYear.Text = HttpContext.GetGlobalResourceObject("English", "Year").ToString();
                // lbtnContact.Text = HttpContext.GetGlobalResourceObject("English", "Contact").ToString();
                lbtnLang.Text = HttpContext.GetGlobalResourceObject("Lang", "Language").ToString();
                // lbtn2018.Text = HttpContext.GetGlobalResourceObject("English", "Y2018").ToString();
                // lbtnPSpeakers.Text = HttpContext.GetGlobalResourceObject("English", "PSpeakers").ToString();
                imgLogo.ImageUrl = HttpContext.GetGlobalResourceObject("English", "Logo").ToString();
                lbtnMedia.Text = HttpContext.GetGlobalResourceObject("English", "Media").ToString();

                lbtnNews.Text = rnews[0]["TypesName"].ToString().Trim();
                lbtnPhoto.Text = rphoto[0]["TypesName"].ToString().Trim();
                lbtnVideo.Text = rvideo[0]["TypesName"].ToString().Trim();
                lbtnContact.Text = rcontact[0]["TypesName"].ToString().Trim();
                txtSearch.Attributes.Add("placeholder", "search");
                break;
        }
    }



    protected void lbtnLang_Click(object sender, EventArgs e)
    {
        switch (lbtnLang.Text)
        {
            case "العربية":
                lang = "L2";
                break;
            case "English":
                lang = "L1";
                break;
            //default:
            //    lang = "L2";
            //    break;



        }

        Response.Cookies.Add(new HttpCookie("Culture", lang));
        cultureCookie = Request.Cookies["Culture"];

        if (lang.Equals("L2"))
        {
            cultureCookie.Value = "L2";
        }
        else
        {
            cultureCookie.Value = "L1";
        }
        Response.SetCookie(cultureCookie);
        Response.Redirect(Request.RawUrl); //Reload and Clear PostBack Data
    }





    protected void lbtnAbout_Click(object sender, EventArgs e)
    {
        Response.Redirect("About.aspx");
    }

    protected void lbtnServices_Click(object sender, EventArgs e)
    {
        Response.Redirect("Services.aspx");
    }

    protected void lbtnContact_Click(object sender, EventArgs e)
    {
        Response.Redirect("Contact.aspx");
    }

    protected void lbtnDBy_Click(object sender, EventArgs e)
    {
        Response.Redirect("http://www.softmaxsolutions.com");
    }


    protected void lbtnNews_Click(object sender, EventArgs e)
    {
        Response.Redirect("Events.aspx");
    }

    protected void lbtnAgenda_Click(object sender, EventArgs e)
    {
        Response.Redirect("Agenda.aspx");
    }

    protected void lbtnPSpeakers_Click(object sender, EventArgs e)
    {
        Response.Redirect("PreviusSpeakers.aspx");
    }
    protected void lbtn2018_Click(object sender, EventArgs e)
    {
        Session["speakers"] = tspeakers2018;
        Response.Redirect("Speakers.aspx");

        //Response.Redirect("Speakers.aspx?c="+tspeakers2018+"&t=2018");
    }

    #region Sub Menu
    public void loadsmenu()
    {
        Category tobj = new Category();
        tobj.CType = "sbytype";
        tobj.TypesId = ttopic;
        dtSMenu1 = cobj.GetCategory(tobj);
        dlSMenu1.DataSource = dtSMenu1;
        dlSMenu1.DataBind();


        //Category tobj1 = new Category();
        //tobj1.CType = "sbytype";
        //tobj1.TypesId = tspeakers;
        //dtSpeak = cobj.GetCategory(tobj1);
        //dlSpeak.DataSource = dtSpeak;
        //dlSpeak.DataBind();

        Category tobj2 = new Category();
        tobj2.CType = "sbytype";
        tobj2.TypesId = tabout;
        dtSMenu2 = cobj.GetCategory(tobj2);
        dlSMenu2.DataSource = dtSMenu2;
        dlSMenu2.DataBind();

    }




    protected void dlSMenu1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item ||
            e.Item.ItemType == ListItemType.AlternatingItem)
        {
            LinkButton lbt1 = (LinkButton)e.Item.FindControl("lblCTitle");
            LinkButton lbt1a = (LinkButton)e.Item.FindControl("lblCTitle1");


            cultureCookie = Request.Cookies["Culture"];
            string cultureCode = (cultureCookie != null) ? cultureCookie.Value : null;

            switch (cultureCode)
            {
                case "L2":
                    lbt1.Visible = false;
                    lbt1a.Visible = true;
                    break;
                case "L1":
                    lbt1.Visible = true;
                    lbt1a.Visible = false;
                    break;
                default:
                    lbt1.Visible = true;
                    lbt1a.Visible = false;
                    break;
            }








        }
    }



    protected void dlSMenu2_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item ||
            e.Item.ItemType == ListItemType.AlternatingItem)
        {
            LinkButton lbt1 = (LinkButton)e.Item.FindControl("lblCTitle");
            LinkButton lbt1a = (LinkButton)e.Item.FindControl("lblCTitle1");


            cultureCookie = Request.Cookies["Culture"];
            string cultureCode = (cultureCookie != null) ? cultureCookie.Value : null;

            switch (cultureCode)
            {
                case "L2":
                    lbt1.Visible = false;
                    lbt1a.Visible = true;
                    break;
                case "L1":
                    lbt1.Visible = true;
                    lbt1a.Visible = false;
                    break;
                default:
                    lbt1.Visible = true;
                    lbt1a.Visible = false;
                    break;
            }








        }
    }



    //protected void dlSpeak_ItemDataBound(object sender, RepeaterItemEventArgs e)
    //{
    //    if (e.Item.ItemType == ListItemType.Item ||
    //        e.Item.ItemType == ListItemType.AlternatingItem)
    //    {
    //        Label lbt1 = (Label)e.Item.FindControl("lblCTitle");
    //        Label lbt1a = (Label)e.Item.FindControl("lblCTitle1");


    //        cultureCookie = Request.Cookies["Culture"];
    //        string cultureCode = (cultureCookie != null) ? cultureCookie.Value : null;

    //        switch (cultureCode)
    //        {
    //            case "L2":
    //                lbt1.Visible = false;
    //                lbt1a.Visible = true;
    //                break;
    //            case "L1":
    //                lbt1.Visible = true;
    //                lbt1a.Visible = false;
    //                break;
    //            default:
    //                lbt1.Visible = true;
    //                lbt1a.Visible = false;
    //                break;
    //        }








    //    }
    //}


    #endregion Sub Menu





    protected void lbtnNews_Click1(object sender, EventArgs e)
    {
        Response.Redirect("News.aspx");
    }

    protected void lbtnPhoto_Click(object sender, EventArgs e)
    {
        Response.Redirect("PhotoGalleryYear.aspx");
    }

    protected void lbtnVideo_Click(object sender, EventArgs e)
    {
        Response.Redirect("VideoGallery.aspx");
    }


    protected void dlSMenu1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        string a = ((Label)e.Item.FindControl("lblCategoryId")).Text.Trim();
        if (e.CommandName == "view")
        {
            Session["topics"] = a;
            if (a == "SC3")
            {
                Response.Redirect("BlockChain.aspx");
            }
            else if (a == "SC1")
            {
                Response.Redirect("CloudComputing.aspx");
            }
            else if (a == "SC5")
            {
                Response.Redirect("CyberSecurity.aspx");
            }
            else if (a == "SC4")
            {
                Response.Redirect("DataAnalytics.aspx");
            }
            else if (a == "SC2")
            {
                Response.Redirect("DigitalTransformation.aspx");
            }
           


        }
    }
    protected void dlSMenu2_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        string a = ((Label)e.Item.FindControl("lblCategoryId")).Text.Trim();
        if (e.CommandName == "view")
        {
            if (a == tcommitteemenu)
            {
                Response.Redirect("Committee.aspx");
            }
            else if (a == "SC28")
            {
                Session["about"] = a;
                Response.Redirect("About.aspx");
            }
            else
            {
                Session["about"] = a;
                Response.Redirect("ChairmanMessage.aspx");
            }


        }
    }



    protected void lbtnSearch_Click(object sender, EventArgs e)
    {
        if (txtSearch.Text.Trim() != "")
        {
            Session["search"] = txtSearch.Text.Trim();
            Response.Redirect("Search.aspx");
        }

    }
}
