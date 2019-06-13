using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using ADAL;
using ABLL;
using System.Web.UI.HtmlControls;
public partial class Forums : System.Web.UI.Page
{
    HttpCookie cultureCookie;
    public string lang;
    ADAL.ADAL cobj = new ADAL.ADAL();
    public static DataTable dtLatest1;
    public static DataTable dtSMenu1;
    public static DataTable dtSpeak;
    static string tspeakers = System.Configuration.ConfigurationSettings.AppSettings["forums"].ToString().Trim();
    static string tspeakers1 = System.Configuration.ConfigurationSettings.AppSettings["speakers"].ToString().Trim();
    static string tid = System.Configuration.ConfigurationSettings.AppSettings["photo"].ToString().Trim();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if(Session["pforum"]!=null)
            {
                lblpid.Text = Session["pforum"].ToString().Trim();
            }
            LoadLang();
            LoadLatest();
        }
    }

    public void LoadLang()
    {

        Types caobj1 = new Types();
        caobj1.CType = "sone";
        caobj1.TypesId = tid;
        DataTable dtca1 = cobj.GetTypes(caobj1);
        cultureCookie = Request.Cookies["Culture"];
        string cultureCode = (cultureCookie != null) ? cultureCookie.Value : null;

        switch (cultureCode)
        {
            case "L2":

                lblPForum.Text = HttpContext.GetGlobalResourceObject("Lang", "PForum").ToString();
                lblPForum1.Text = HttpContext.GetGlobalResourceObject("Lang", "PForum").ToString();
                lblPForum2.Text = HttpContext.GetGlobalResourceObject("Lang", "PForum").ToString();
                lblSpeakers.Text = HttpContext.GetGlobalResourceObject("Lang", "Speakers").ToString();
                if (dtca1.Rows.Count > 0)
                {
                    lbtnpyear1.Text = dtca1.Rows[0]["TypesName1"].ToString().Trim();
                }
                break;
            case "L1":

                lblPForum.Text = HttpContext.GetGlobalResourceObject("English", "PForum").ToString();
                lblPForum1.Text = HttpContext.GetGlobalResourceObject("English", "PForum").ToString();
                lblPForum2.Text = HttpContext.GetGlobalResourceObject("English", "PForum").ToString();
                lblSpeakers.Text = HttpContext.GetGlobalResourceObject("English", "Speakers").ToString();
                if (dtca1.Rows.Count > 0)
                {
                    lbtnpyear1.Text = dtca1.Rows[0]["TypesName"].ToString().Trim();
                }

                break;
            default:

                lblPForum.Text = HttpContext.GetGlobalResourceObject("English", "PForum").ToString();
                lblPForum1.Text = HttpContext.GetGlobalResourceObject("English", "PForum").ToString();
                lblPForum2.Text = HttpContext.GetGlobalResourceObject("English", "PForum").ToString();
                lblSpeakers.Text = HttpContext.GetGlobalResourceObject("English", "Speakers").ToString();
                if (dtca1.Rows.Count > 0)
                {
                    lbtnpyear1.Text = dtca1.Rows[0]["TypesName"].ToString().Trim();
                }
                break;
        }
    }


    public void LoadLatest()
    {
      
        Category aobj2 = new Category();
        aobj2.TypesId = tspeakers;
        aobj2.CType = "sbytype";

        dtLatest1 = cobj.GetCategory(aobj2);

       // dtLatest1 = dtLatest1.Rows.Cast<System.Data.DataRow>().Take(4).CopyToDataTable();

        dlLatest1.DataSource = dtLatest1;
        dlLatest1.DataBind();




    }

    protected void dlLatest1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item ||
           e.Item.ItemType == ListItemType.AlternatingItem)
        {


            LinkButton lbtit = (LinkButton)e.Item.FindControl("lblTitle");
            LinkButton lbtit1 = (LinkButton)e.Item.FindControl("lblTitle1");

            Label lbid = (Label)e.Item.FindControl("lblProductId");

           // Image lbimg = (Image)e.Item.FindControl("imgc");

            

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


            HtmlControl hc = (HtmlControl)e.Item.FindControl("yforum");
            if (lblpid.Text.Trim()==lbid.Text.Trim())
            {
                hc.Attributes["class"] = "active";
                Contents cobjc = new Contents();
                cobjc.CType = "sbycata";
                cobjc.TypesId = tspeakers;
                cobjc.CategoryId = lbid.Text;
                lbtnpyear.Text = lbtit.Text;

                DataTable dtc1 = cobj.GetContents(cobjc);

                string cc = "";
                switch (cultureCode)
                {
                    case "L2":
                        
                        if (dtc1.Rows.Count > 0)
                        {
                            cc = dtc1.Rows[0]["ContentDetail1"].ToString().Trim();
                        }

                        break;
                    case "L1":
                      
                        if (dtc1.Rows.Count > 0)
                        {
                            cc = dtc1.Rows[0]["ContentDetail"].ToString().Trim();
                        }

                        break;
                    default:
                     
                        if (dtc1.Rows.Count > 0)
                        {
                            cc = dtc1.Rows[0]["ContentDetail"].ToString().Trim();
                        }


                        break;
                }



                fcont.InnerHtml = cc;
                fcont.DataBind();
                LoadSpeaker(lbtit.Text.Trim());
                
            }
            else
            {
                hc.Attributes["class"] = "";
                //fcont.InnerHtml = "";
            }

        }
    }

    public void LoadSpeaker(string a)
    {
        

        Contents tobj = new Contents();
        tobj.CType = "sbytypea";
        tobj.TypesId = tspeakers1;
        DataTable dtContent = cobj.GetContents(tobj);

        DataRow[] rows = dtContent.Select("CategoryName='" + a + "'");

        if(rows.Count()>0)
        {
            dtContent = dtContent.Select("CategoryName='" + a + "'").CopyToDataTable();
            
        }
        else
        {
            dtContent = null;
        }
        dlCont.DataSource = dtContent;
        dlCont.DataBind();

    }



    protected void dlLatest1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        string a = ((Label)e.Item.FindControl("lblProductId")).Text.Trim();
        if (e.CommandName == "view")
        {
            lblpid.Text = a;
            LoadLatest();

        }
    }


    protected void dlCont_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item ||
            e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Label lbt1 = (Label)e.Item.FindControl("lblCTitle");
            Label lbt1a = (Label)e.Item.FindControl("lblCTitle1");
            //Label lbts1 = (Label)e.Item.FindControl("lblShort");
            //Label lbts1a = (Label)e.Item.FindControl("lblShort1");
            //Label lbtm1 = (Label)e.Item.FindControl("lblDet");
            //Label lbtm1a = (Label)e.Item.FindControl("lblDet1");
            Label lblc = (Label)e.Item.FindControl("lblCategoryId1");
            HtmlControl hc = (HtmlControl)e.Item.FindControl("cssspeak");

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
                    //lbts1.Visible = false;
                    //lbts1a.Visible = true;
                    //lbtm1.Visible = false;
                    //lbtm1a.Visible = true;
                    break;
                case "L1":
                    lbt1.Visible = true;
                    lbt1a.Visible = false;
                    //lbts1.Visible = true;
                    //lbts1a.Visible = false;
                    //lbtm1.Visible = true;
                    //lbtm1a.Visible = false;
                    break;
                default:
                    lbt1.Visible = true;
                    lbt1a.Visible = false;
                    //lbts1.Visible = true;
                    //lbts1a.Visible = false;
                    //lbtm1.Visible = true;
                    //lbtm1a.Visible = false;
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




    protected void lbtnpyear_Click(object sender, EventArgs e)
    {
        Category aobja = new Category();
        aobja.TypesId = tid;
        aobja.CType = "sbytype";

        DataTable dtaa = cobj.GetCategory(aobja);
        DataRow[] rows = dtaa.Select("CategoryName='" + lbtnpyear.Text.Trim() + "'");

        if (rows.Count() > 0)
        {
            Session["pgallery"] = rows[0]["CategoryId"].ToString().Trim();
            Response.Redirect("PhotoGallery.aspx");

        }

       
    }
    protected void lbtnpyear1_Click(object sender, EventArgs e)
    {
        Category aobja = new Category();
        aobja.TypesId = tid;
        aobja.CType = "sbytype";

        DataTable dtaa = cobj.GetCategory(aobja);
        DataRow[] rows = dtaa.Select("CategoryName='" + lbtnpyear.Text.Trim() + "'");

        if (rows.Count() > 0)
        {
            Session["pgallery"] = rows[0]["CategoryId"].ToString().Trim();
            Response.Redirect("PhotoGallery.aspx");

        }
    }
}