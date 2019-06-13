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
public partial class _Default : System.Web.UI.Page
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
    RDAL robj = new RDAL();
    static string tid = System.Configuration.ConfigurationSettings.AppSettings["news"].ToString().Trim();
    static string vid = System.Configuration.ConfigurationSettings.AppSettings["video"].ToString().Trim();
    static string thome = System.Configuration.ConfigurationSettings.AppSettings["home"].ToString().Trim();
    static string thomefeed = System.Configuration.ConfigurationSettings.AppSettings["homefeed"].ToString().Trim();
    static string thomeforum = System.Configuration.ConfigurationSettings.AppSettings["homeforum"].ToString().Trim();
    static string thomehelp = System.Configuration.ConfigurationSettings.AppSettings["homehelp"].ToString().Trim();
    static string tspeakers2018 = System.Configuration.ConfigurationSettings.AppSettings["speakers2018"].ToString().Trim();
    static string tspeakers = System.Configuration.ConfigurationSettings.AppSettings["speakers"].ToString().Trim();
    static string tphoto = System.Configuration.ConfigurationSettings.AppSettings["photo"].ToString().Trim();

    static string tmenu = System.Configuration.ConfigurationSettings.AppSettings["smenu"].ToString().Trim();
    static string tmenu1 = System.Configuration.ConfigurationSettings.AppSettings["smenu1"].ToString().Trim();
    static string tmenu2 = System.Configuration.ConfigurationSettings.AppSettings["smenu2"].ToString().Trim();
    static string tmenu3 = System.Configuration.ConfigurationSettings.AppSettings["smenu3"].ToString().Trim();
    static string tmenu4 = System.Configuration.ConfigurationSettings.AppSettings["smenu4"].ToString().Trim();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadLang();
            //LoadProducts();
            LoadCategory();
            LoadLatest();
            LoadView();
        }
    }
    public void LoadLang()
    {
        cultureCookie = Request.Cookies["Culture"];
        string cultureCode = (cultureCookie != null) ? cultureCookie.Value : null;
        Contents tobj = new Contents();
        tobj.CType = "sbytypea";
        tobj.TypesId = thome;
        dtContent = cobj.GetContents(tobj);

        Contents tobj1 = new Contents();
        tobj1.CType = "sbytypea";
        tobj1.TypesId = thomeforum;
        dtContent1 = cobj.GetContents(tobj1);

        Contents tobj2 = new Contents();
        tobj2.CType = "sbytypea";
        tobj2.TypesId = thomefeed;
        dtContent2 = cobj.GetContents(tobj2);

        Contents tobj3 = new Contents();
        tobj3.CType = "sbytypea";
        tobj3.TypesId = thomehelp;
        dtContent3 = cobj.GetContents(tobj3);

        mdisp.Attributes.Add("direction", "left");
    
        switch (cultureCode)
        {
            case "L2":
                mdisp.Attributes.Add("direction", "right");
                if (dtContent.Rows.Count > 0)
                {
                    haus.InnerHtml = dtContent.Rows[0]["ContentDetail1"].ToString().Trim();
                }
                if (dtContent1.Rows.Count > 0)
                {
                    haus1.InnerHtml = dtContent1.Rows[0]["ContentDetail1"].ToString().Trim();
                }
                if (dtContent2.Rows.Count > 0)
                {
                   // haus2.InnerHtml = dtContent2.Rows[0]["ContentDetail1"].ToString().Trim();
                }
                if (dtContent3.Rows.Count > 0)
                {
                  haus3.InnerHtml = dtContent3.Rows[0]["ContentDetail1"].ToString().Trim();
                }
                lblLnews.Text = "آخر الأخبار";
                // lblESpeaker.Text = "المتحدثون الحدث";
                lblESpeaker.Text = "المتحدثين";
                lblPGallery.Text = "معرض الصور";
                lblVGallery.Text = "عرض جميع الصور";
                lblHNews.Text = "الأخبار";
                //lblASpeakers.Text = "عرض كل مكبرات الصوت";

                lblASpeakers.Text = "عرض جميع المتحدثين";
                break;
            case "L1":
                mdisp.Attributes.Add("direction", "left");
                if (dtContent.Rows.Count > 0)
                {
                    haus.InnerHtml = dtContent.Rows[0]["ContentDetail"].ToString().Trim();
                }
                if (dtContent1.Rows.Count > 0)
                {
                    haus1.InnerHtml = dtContent1.Rows[0]["ContentDetail"].ToString().Trim();
                }
                if (dtContent2.Rows.Count > 0)
                {
                   // haus2.InnerHtml = dtContent2.Rows[0]["ContentDetail"].ToString().Trim();
                }
                if (dtContent3.Rows.Count > 0)
                {
                   haus3.InnerHtml = dtContent3.Rows[0]["ContentDetail"].ToString().Trim();
                }
                lblLnews.Text = "Latest News";
                lblESpeaker.Text = "Event Speakers";
                lblPGallery.Text = "Photo Gallery";
                lblVGallery.Text = "View Full Gallery";
                lblHNews.Text = "News";
                lblASpeakers.Text = "View All Speakers";
                break;
            default:
                mdisp.Attributes.Add("direction", "left");
                if (dtContent.Rows.Count > 0)
                {
                    haus.InnerHtml = dtContent.Rows[0]["ContentDetail"].ToString().Trim();
                }
                if (dtContent1.Rows.Count > 0)
                {
                    haus1.InnerHtml = dtContent1.Rows[0]["ContentDetail"].ToString().Trim();
                }
                if (dtContent2.Rows.Count > 0)
                {
                   // haus2.InnerHtml = dtContent2.Rows[0]["ContentDetail"].ToString().Trim();
                }
                if (dtContent3.Rows.Count > 0)
                {
                    haus3.InnerHtml = dtContent3.Rows[0]["ContentDetail"].ToString().Trim();
                }
                lblLnews.Text = "Latest News";
                lblESpeaker.Text = "Event Speakers";
                lblPGallery.Text = "Photo Gallery";
                lblVGallery.Text = "View Full Gallery";
                lblHNews.Text = "News";
                lblASpeakers.Text = "View All Speakers";
                break;
        }
    }

    public void LoadProducts()
    {
        //Productsc aobj = new Productsc();
        //aobj.CType = "selectall";
        //ds = cobj.GetProductsDS(aobj);
        //dlProducts.DataSource = ds;
        //dlProducts.DataBind();
    }

    protected void dlProducts_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item ||
           e.Item.ItemType == ListItemType.AlternatingItem)
        {


            Label lbtit = (Label)e.Item.FindControl("lblTitle");
            Label lbtit1 = (Label)e.Item.FindControl("lblTitle1");
            //Label lbadr = (Label)e.Item.FindControl("lblShort");
            //Label lbadr1 = (Label)e.Item.FindControl("lblShort1");
            Image lbimg = (Image)e.Item.FindControl("imgp");
            if (lbimg.ImageUrl.ToString().Trim() == "")
            {
                lbimg.ImageUrl = "images/thagam-english-logo.png";
            }

            cultureCookie = Request.Cookies["Culture"];
            string cultureCode = (cultureCookie != null) ? cultureCookie.Value : null;

            switch (cultureCode)
            {
                case "L2":
                    lbtit.Visible = false;
                    lbtit1.Visible = true;
                    //lbadr.Visible = false;
                    //lbadr1.Visible = true;
                    break;
                case "L1":
                    lbtit.Visible = true;
                    lbtit1.Visible = false;
                    //lbadr.Visible = true;
                    //lbadr1.Visible = false;
                    break;
                default:
                    lbtit.Visible = true;
                    lbtit1.Visible = false;
                    //lbadr.Visible = true;
                    //lbadr1.Visible = false;
                    break;
            }


        }
    }




    #region Category


    public void LoadCategory()
    {
        //Category mobj = new Category();
        //mobj.CType = "sbytype";
        //mobj.TypesId = tid;
        //dtCategory = cobj.GetCategory(mobj);
        //dlCategory.DataSource = dtCategory;
        //dlCategory.DataBind();
    }

    //protected void dlHmenu_ItemDataBound(object sender, DataListItemEventArgs e)
    protected void dlCategory_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item ||
            e.Item.ItemType == ListItemType.AlternatingItem)
        {
            LinkButton lbt1 = (LinkButton)e.Item.FindControl("lbtnCategoryName");
            LinkButton lbt1a = (LinkButton)e.Item.FindControl("lbtnCategoryName1");


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
    //protected void dlHmenu_ItemCommand(object source, DataListCommandEventArgs e)
    protected void dlCategory_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        string a = ((Label)e.Item.FindControl("lblCategoryId")).Text.Trim();
        string c = ((LinkButton)e.Item.FindControl("lbtnCategoryName")).Text.Trim();
        string d = ((LinkButton)e.Item.FindControl("lbtnCategoryName1")).Text.Trim();
        string f = "";
        cultureCookie = Request.Cookies["Culture"];
        string cultureCode = (cultureCookie != null) ? cultureCookie.Value : null;

        switch (cultureCode)
        {
            case "L2":
                f = d;
                break;
            case "L1":
                f = c;
                break;
            default:
                f = c;
                break;
        }

        if (e.CommandName == "view")
        {
            Response.Redirect("Events.aspx?c=" + a + "&n=" + f);

        }
    }


    #endregion Category



    #region Slide


      
    protected void dlSlide_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item ||
            e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Label lbt1 = (Label)e.Item.FindControl("lblCTitle");
            Label lbt1a = (Label)e.Item.FindControl("lblCTitle1");
            Label lbts1 = (Label)e.Item.FindControl("lblShort");
            Label lbts1a = (Label)e.Item.FindControl("lblShort1");
            Label lbts2 = (Label)e.Item.FindControl("lblDet");
            Label lbts2a = (Label)e.Item.FindControl("lblDet1");
            Label lblc = (Label)e.Item.FindControl("lblCategoryId");

            HtmlControl hc = (HtmlControl)e.Item.FindControl("slcsse");
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

            switch (cultureCode)
            {
                case "L2":
                    lbt1.Visible = false;
                    lbt1a.Visible = true;
                    lbts1.Visible = false;
                    lbts1a.Visible = true;
                    lbts2.Visible = false;
                    lbts2a.Visible = true;
                    break;
                case "L1":
                    lbt1.Visible = true;
                    lbt1a.Visible = false;
                    lbts1.Visible = true;
                    lbts1a.Visible = false;
                    lbts2.Visible = true;
                    lbts2a.Visible = false;
                    break;
                default:
                    lbt1.Visible = true;
                    lbt1a.Visible = false;
                    lbts1.Visible = true;
                    lbts1a.Visible = false;
                    lbts2.Visible = true;
                    lbts2a.Visible = false;
                    break;
            }








        }
    }


    #endregion Slide


    #region Break



    protected void dlBreak_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item ||
            e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Label lbt1 = (Label)e.Item.FindControl("lblCTitle");
            Label lbt1a = (Label)e.Item.FindControl("lblCTitle1");


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


    #endregion Break

    #region Latest

    public void LoadLatest()
    {
       Contents aobj = new Contents();
        aobj.TypesId = tid;
        aobj.CType = "sbytypeatop4a";
        //dtLatest = cobj.GetContents(aobj);
        dtLatest = robj.GetPub4(tid);

        dlLatest.DataSource = dtLatest;
        dlLatest.DataBind();

        dlLatest2.DataSource = dtLatest;
        dlLatest2.DataBind();



        //Contents aobj2 = new Contents();
        //aobj2.TypesId = tphoto;
        //aobj2.CType = "sbytypeatop4a";
        //dtLatest1 = cobj.GetContents(aobj2);
        //dlLatest1.DataSource = dtLatest1;
        //dlLatest1.DataBind();

        Category aobj2 = new Category();
        aobj2.TypesId = tphoto;
        aobj2.CType = "sbytype";

        dtLatest1 = cobj.GetCategory(aobj2);

        dtLatest1 = dtLatest1.Rows.Cast<System.Data.DataRow>().Take(4).CopyToDataTable();

        dlLatest1.DataSource = dtLatest1;
        dlLatest1.DataBind();




        Contents aobj3 = new Contents();
        aobj3.TypesId = tspeakers;
        aobj3.CategoryId = tspeakers2018;
        aobj3.CType = "sbycata";
        dtSlide = cobj.GetContents(aobj3);


        DataTable dtMarks1 = dtSlide.Clone();
        dtMarks1.Columns["Price"].DataType = Type.GetType("System.Int32");

        foreach (DataRow dr in dtSlide.Rows)
        {
            dtMarks1.ImportRow(dr);
        }
        dtMarks1.AcceptChanges();


        DataView dv = dtMarks1.DefaultView;
        dv.Sort = "Price ASC";
        DataTable dta1 = dv.ToTable();

       // DataTable dta2 = dta1.Rows.Cast<System.Data.DataRow>().Take(4).CopyToDataTable();

       // dlSlide.DataSource = dta2;

        dlSlide.DataSource = dta1;
        dlSlide.DataBind();


        //dlSlide.DataSource = dtSlide;
        //dlSlide.DataBind();

    }

    protected void dlLatest_ItemDataBound(object sender, RepeaterItemEventArgs e)
{
        if (e.Item.ItemType == ListItemType.Item ||
           e.Item.ItemType == ListItemType.AlternatingItem)
        {


            Label lbtit = (Label)e.Item.FindControl("lblTitle");
            Label lbtit1 = (Label)e.Item.FindControl("lblTitle1");
            Label lbsho = (Label)e.Item.FindControl("lblShort");
            Label lbsho1 = (Label)e.Item.FindControl("lblShort1");
            Label lblc = (Label)e.Item.FindControl("lblCategoryId");
            // Label lbadr = (Label)e.Item.FindControl("lblView");
            LinkButton lbadr = (LinkButton)e.Item.FindControl("lblView");

            Label lbmon = (Label)e.Item.FindControl("lblMonth");

            string mont = lbmon.Text.Trim();

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

            switch (cultureCode)
            {
                case "L2":
                    lbtit.Visible = false;
                    lbtit1.Visible = true;

                    lbsho.Visible = false;
                    lbsho1.Visible = true;

                    if (mont == "January")
                    {
                        lbmon.Text = "يناير ";
                    }
                    else if (mont == "February")
                    {
                        lbmon.Text = "فبراير ";
                    }
                    else if (mont == "March")
                    {
                        lbmon.Text = "مارس ";
                    }
                    else if (mont == "April")
                    {
                        lbmon.Text = "إبريل ";
                    }
                    else if (mont == "May")
                    {
                        lbmon.Text = "قد";
                    }
                    else if (mont == "June")
                    {
                        lbmon.Text = "يونيو ";
                    }
                    else if (mont == "July")
                    {
                        lbmon.Text = "يوليو ";
                    }
                    else if (mont == "August")
                    {
                        lbmon.Text = "أغسطس ";
                    }
                    else if (mont == "September")
                    {
                        lbmon.Text = "سبتمبر";
                    }
                    else if (mont == "October")
                    {
                        lbmon.Text = "أكتوبر";
                    }
                    else if (mont == "November")
                    {
                        lbmon.Text = "نوفمبر";
                    }
                    else if (mont == "December")
                    {
                        lbmon.Text = "ديسمبر";
                    }



                    lbadr.Text = HttpContext.GetGlobalResourceObject("Lang", "ReadMore").ToString();
                    break;
                case "L1":
                    lbtit.Visible = true;
                    lbtit1.Visible = false;

                    lbsho.Visible = true;
                    lbsho1.Visible = false;

                    lbmon.Text = mont;

                    lbadr.Text = HttpContext.GetGlobalResourceObject("English", "ReadMore").ToString();

                    break;
                default:
                    lbtit.Visible = true;
                    lbtit1.Visible = false;

                    lbmon.Text = mont;

                    lbsho.Visible = true;
                    lbsho1.Visible = false;

                   lbadr.Text = HttpContext.GetGlobalResourceObject("English", "ReadMore").ToString();

                    break;
            }




        }
    }

    protected void dlLatest2_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item ||
           e.Item.ItemType == ListItemType.AlternatingItem)
        {


            Label lbtit = (Label)e.Item.FindControl("lblTitle");
            Label lbtit1 = (Label)e.Item.FindControl("lblTitle1");
           

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


            LinkButton lbtit = (LinkButton)e.Item.FindControl("lblTitle");
            LinkButton lbtit1 = (LinkButton)e.Item.FindControl("lblTitle1");

            Label lbid = (Label)e.Item.FindControl("lblProductId");

            Image lbimg = (Image)e.Item.FindControl("imgc");

            Contents cobjc = new Contents();
            cobjc.CType = "sbycata";
            cobjc.TypesId = tphoto;
            cobjc.CategoryId = lbid.Text;

            DataTable dtc1 = cobj.GetContents(cobjc);

            if (dtc1.Rows.Count > 0)
            {
                lbimg.ImageUrl = dtc1.Rows[0]["DImage"].ToString().Trim();
            }

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




    protected void dlLatest1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        string a = ((Label)e.Item.FindControl("lblProductId")).Text.Trim();
        if (e.CommandName == "view")
        {
            Session["pgallery"] = a;
            Response.Redirect("PhotoGallery.aspx");

        }
    }
    protected void dlLatest_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        string a = ((Label)e.Item.FindControl("lblProductId")).Text.Trim();
        if (e.CommandName == "view")
        {
            Session["news"] = a;
            Response.Redirect("NewsDetail.aspx");

        }
    }

    #endregion Latest


    #region View

    public void LoadView()
    {
        Contents aobj = new Contents();
        aobj.TypesId = tid;
        aobj.CType = "sbytypeatop4view";
        dtView = cobj.GetContents(aobj);

        //dlView.DataSource = dtView;
        //dlView.DataBind();
    }

    //protected void dlView_ItemDataBound(object sender, RepeaterItemEventArgs e)
    //{
    //    if (e.Item.ItemType == ListItemType.Item ||
    //       e.Item.ItemType == ListItemType.AlternatingItem)
    //    {


    //        Label lbtit = (Label)e.Item.FindControl("lblTitle");
    //        Label lbtit1 = (Label)e.Item.FindControl("lblTitle1");
    //        //Label lbsho = (Label)e.Item.FindControl("lblShort");
    //        //Label lbsho1 = (Label)e.Item.FindControl("lblShort1");
    //        Label lbv = (Label)e.Item.FindControl("lblViews");
    //        Label lbv1 = (Label)e.Item.FindControl("lblViews1");

    //        //Label lbadr = (Label)e.Item.FindControl("lblView");

    //        Image lbimg = (Image)e.Item.FindControl("imgp");
    //        if (lbimg.ImageUrl.ToString().Trim() == "")
    //        {
    //            lbimg.ImageUrl = "img/pragathi-pathe-media-logo.png";
    //        }

    //        cultureCookie = Request.Cookies["Culture"];
    //        string cultureCode = (cultureCookie != null) ? cultureCookie.Value : null;

    //        switch (cultureCode)
    //        {
    //            case "L2":
    //                lbtit.Visible = false;
    //                lbtit1.Visible = true;

    //                //lbsho.Visible = false;
    //                //lbsho1.Visible = true;

    //                lbv.Visible = false;
    //                lbv1.Visible = true;

    //                //lbadr.Text = HttpContext.GetGlobalResourceObject("Lang", "ReadMore").ToString();
    //                break;
    //            case "L1":
    //                lbtit.Visible = true;
    //                lbtit1.Visible = false;

    //                //lbsho.Visible = true;
    //                //lbsho1.Visible = false;

    //                lbv.Visible = true;
    //                lbv1.Visible = false;

    //                // lbadr.Text = HttpContext.GetGlobalResourceObject("English", "ReadMore").ToString();

    //                break;
    //            default:
    //                lbtit.Visible = true;
    //                lbtit1.Visible = false;

    //                //lbsho.Visible = true;
    //                //lbsho1.Visible = false;

    //                lbv.Visible = true;
    //                lbv1.Visible = false;

    //                // lbadr.Text = HttpContext.GetGlobalResourceObject("English", "ReadMore").ToString();

    //                break;
    //        }




    //    }
    //}


    #endregion View



    protected void lbtnSm1_Click(object sender, EventArgs e)
    {
        Session["topics"] = tmenu;
        Response.Redirect("Topics.aspx");
       // ScriptManager.RegisterClientScriptBlock(UpdatePanel1, this.GetType(), "script", "window.open ('Topics.aspx','_blank');", true);

        // Response.Redirect("Topics.aspx?c=" + tmenu);
    }
    protected void lbtnSm2_Click(object sender, EventArgs e)
    {
        Session["topics"] = tmenu1;
        Response.Redirect("Topics.aspx");
       // ScriptManager.RegisterClientScriptBlock(UpdatePanel1, this.GetType(), "script", "window.open ('Topics.aspx','_blank');", true);

        //Response.Redirect("Topics.aspx?c=" + tmenu1);
    }
    protected void lbtnSm3_Click(object sender, EventArgs e)
    {
        Session["topics"] = tmenu2;
         Response.Redirect("Topics.aspx");
        // Response.Redirect("Topics.aspx?c=" + tmenu2);
       // ScriptManager.RegisterClientScriptBlock(UpdatePanel1, this.GetType(), "script", "window.open ('Topics.aspx','_blank');", true);

    }
    protected void lbtnSm4_Click(object sender, EventArgs e)
    {
        Session["topics"] = tmenu3;
        Response.Redirect("Topics.aspx");
        // Response.Redirect("Topics.aspx?c=" + tmenu3);
       // ScriptManager.RegisterClientScriptBlock(UpdatePanel1, this.GetType(), "script", "window.open ('Topics.aspx','_blank');", true);

    }
    protected void lbtnSm5_Click(object sender, EventArgs e)
    {
        Session["topics"] = tmenu4;
        Response.Redirect("Topics.aspx");
        // Response.Redirect("Topics.aspx?c=" + tmenu4);
       // ScriptManager.RegisterClientScriptBlock(UpdatePanel1, this.GetType(), "script", "window.open ('Topics.aspx','_blank');", true);

    }

    protected void dlSlide_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        string a = ((Label)e.Item.FindControl("lblprodid")).Text.Trim();
        if (e.CommandName == "view")
        {
            Session["speakerdetail"] = a;
            Response.Redirect("SpeakerDetail.aspx");

        }
    }
}